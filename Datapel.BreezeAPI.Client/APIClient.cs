﻿using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Configuration;
using System.Linq;


namespace Datapel.BreezeAPI.SDK.Client
{
    /// <summary>
    /// This class is used to make API calls 
    /// </summary>
    /// <remarks>
    /// You will first need to use the APIAuthorizer to obtain the required authorization.
    /// </remarks>
    public class APIClient
    {

        private string BreezeAPIPath = ConfigurationManager.AppSettings["BreezeAPI.MainPath"];
        private string AuthTokenHeader = ConfigurationManager.AppSettings["BreezeAPI.Header.AuthToken"];
        private string AuthorizationHeader = ConfigurationManager.AppSettings["BreezeAPI.Header.Authorization"];

        /// <summary>
        /// Creates an instance of this class for use with making API Calls
        /// </summary>
        /// <param name="state">the authorization state required to make the API Calls</param>
        public APIClient(AuthorisationState state)
        {
            this.State = state;
            ReturnTypeString = ConfigurationManager.AppSettings["BreezeAPI.ReturnType"];
        }

        /// <summary>
        /// Creates an instance of this class for use with making API Calls
        /// </summary>
        /// <param name="state">the authorization state required to make the API Calls</param>
        /// <param name="translator">the translator used to transform the data between your C# client code and the API</param>
        public APIClient(AuthorisationState state, IDataTranslator translator)
        {
            this.State = state;
            this.Translator = translator;
        }

        /// <summary>
        /// Make an HTTP Request to the API
        /// </summary>
        /// <param name="method">method to be used in the request</param>
        /// <param name="path">the path that should be requested</param>
        /// <returns>the server response</returns>
        public object Call(HttpMethods method, string path)
        {
            return Call(method, path, null);
        }

        /// <summary>
        /// Make an HTTP Request to the API
        /// </summary>
        /// <param name="method">method to be used in the request</param>
        /// <param name="path">the path that should be requested</param>
        /// <param name="callParams">any parameters needed or expected by the API</param>
        /// <returns>the server response</returns>
        public object Call(HttpMethods method, string path, object callParams)
        {            

            string url = (BreezeAPIPath.EndsWith("/") ? BreezeAPIPath : (BreezeAPIPath += "/")) + ReturnTypeString + "/"; // hard code to json to get the Auth_token.            
            url += path; 

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = GetRequestContentType();            
            request.Method = method.ToString();
            SetHeader(request); 

            if (callParams != null)
            {
                if (method == HttpMethods.GET || method == HttpMethods.DELETE)
                {
                    // if no translator assume data is a query string
                    url = String.Format("{0}?{1}", url, callParams.ToString());

                    //// put params into query string
                    //StringBuilder queryString = new StringBuilder();
                    //foreach (string key in callParams.Keys)
                    //{
                    //    queryString.AppendFormat("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(callParams[key]));
                    //}
                }
                else if (method == HttpMethods.POST || method == HttpMethods.PUT)
                {
                    string requestBody;
                    // put params into post body
                    if (Translator == null)
                    {
                        //assume it's a string
                        requestBody = callParams.ToString();
                    }
                    else
                    {
                        requestBody = Translator.Encode(callParams);
                    }

                    //add the requst body to the request stream
                    if (!String.IsNullOrEmpty(requestBody))
                    {
                        using (var ms = new MemoryStream())
                        {
                            using (var writer = new StreamWriter(request.GetRequestStream()))
                            {
                                writer.Write(requestBody);
                                writer.Close();
                            }
                        }
                    }
                }
            }

            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode != HttpStatusCode.Created &&
                response.StatusCode != HttpStatusCode.OK)
            {
                throw new WebException("", null, WebExceptionStatus.UnknownError, response); 
            }

            string result = null;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result = sr.ReadToEnd();
                sr.Close();
            }

            if (Translator != null)
                return Translator.Decode(result);

            return result;

        }

        /// <summary>
        /// Make a Get method HTTP request to the API
        /// </summary>
        /// <param name="path">the path where the API call will be made.</param>
        /// <returns>the server response</returns>
        public object Get(string path)
        {
            return Get(path, null);
        }

        /// <summary>
        /// Make a Get method HTTP request to the API
        /// </summary>
        /// <param name="path">the path where the API call will be made.</param>
        /// <param name="callParams">the querystring params</param>
        /// <returns>the server response</returns>
        public object Get(string path, NameValueCollection callParams)
        {
            return Call(HttpMethods.GET, path, callParams);
        }

        /// <summary>
        /// Make a Post method HTTP request to the API
        /// </summary>
        /// <param name="path">the path where the API call will be made.</param>
        /// <param name="data">the data that this path will be expecting</param>
        /// <returns>the server response</returns>
        public object Post(string path, object data)
        {
            return Call(HttpMethods.POST, path, data);
        }

        /// <summary>
        /// Make a Put method HTTP request to the API
        /// </summary>
        /// <param name="path">the path where the API call will be made.</param>
        /// <param name="data">the data that this path will be expecting</param>
        /// <returns>the server response</returns>
        public object Put(string path, object data)
        {
            return Call(HttpMethods.PUT, path, data);
        }

        /// <summary>
        /// Make a Delete method HTTP request to the API
        /// </summary>
        /// <param name="path">the path where the API call will be made.</param>
        /// <returns>the server response</returns>
        public object Delete(string path)
        {
            return Call(HttpMethods.DELETE, path);
        }

        /// <summary>
        /// Get the content type that should be used for HTTP Requests
        /// </summary>
        private string GetRequestContentType()
        {
            if (Translator == null)
                return DefaultContentType;
            return Translator.GetContentType();
        }

        /// <summary>
        /// The enumeration of HTTP Methods used by the API
        /// </summary>
        public string ReturnTypeString
        {
            get
            {
                return ReturnType.ToString(); 
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    ReturnType = BreezeReturnType.json;
                }
                else
                {
                    BreezeReturnType ret;
                    if (Enum.TryParse<BreezeReturnType>(value, out ret))
                    {
                        ReturnType = ret;
                    }
                    else
                    {
                        ReturnType = BreezeReturnType.json; 
                    }
                }

            }
        }

        public BreezeReturnType ReturnType { get; set; }

        /// <summary>
        /// The default content type used on the HTTP Requests to the API
        /// </summary>
        protected static readonly string DefaultContentType = "application/json";
        
        /// <summary>
        /// The state required to make API calls.  It contains the access token and
        /// the name of the shop that your app will make calls on behalf of
        /// </summary>
        protected AuthorisationState State { get; set; }

        /// <summary>
        /// Used to translate the data sent and recieved by the API
        /// </summary>
        /// <example>
        /// This could be used to translate from C# objects to XML or JSON.  Thus making your code
        /// that consumes this class much more clean
        /// </example>
        protected IDataTranslator Translator { get; set; }
        
        protected void SetHeader (HttpWebRequest webrq)
        {
            var header = webrq.Headers;

            if (header.AllKeys.Any(k => k == AuthTokenHeader))
            {
                header[AuthTokenHeader] = State.Auth_Token;
            }
            else
            {
                header.Add(AuthTokenHeader, State.Auth_Token);
            }


            if (header.AllKeys.Any(k => k == AuthorizationHeader))
            {
                header[AuthorizationHeader] = State.AuthorisationCode; 
            }
            else
            {
                header.Add(AuthorizationHeader, State.AuthorisationCode);
            }
        }

    }

    public enum HttpMethods
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum BreezeReturnType
    {
        json,
        html,
        xml,
        pdf
    }

 
}
