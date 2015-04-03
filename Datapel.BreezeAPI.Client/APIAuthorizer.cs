using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Datapel.BreezeAPI.SDK.Client
{
    /// <summary>
    /// this class is used to obtain the authorization
    /// from the shopify customer to make api calls on their behalf
    /// </summary>
    public class APIAuthorizer
    {

        private string BreezeAPIPath = ConfigurationManager.AppSettings["BreezeAPI.MainPath"];
        private string returnType = ConfigurationManager.AppSettings["BreezeAPI.ReturnType"];
        private string AuthToken = ConfigurationManager.AppSettings["BreezeAPI.Header.AuthToken"];
        private string Authorisation = ConfigurationManager.AppSettings["BreezeAPI.Header.Authorization"];

        public APIAuthorizer()
        { }


        ///// <summary>
        ///// Creates an instance of this class in order to obtain the authorization
        ///// from the shopify customer to make api calls on their behalf
        ///// </summary>
        ///// <param name="shopName">name of the shop to make the calls for.</param>
        ///// <param name="apiKey">the unique api key of your app (obtained from the partner area when you create an app).</param>
        ///// <param name="secret">the secret associated with your api key.</param>
        ///// <remarks>make sure that the shop name parameter is the only the subdomain part of the myshopify.com url.</remarks>
        //public APIAuthorizer(string shopName, string apiKey, string secret)
        //{
        //    if (shopName == null)
        //        throw new ArgumentNullException("shopName");
        //    if (apiKey == null)
        //        throw new ArgumentNullException("apiKey", "Make sure you have this in your config file.");
        //    if (secret == null)
        //        throw new ArgumentNullException("secret", "Make sure you have this in your config file.");

        //    if (shopName.Length == 0)
        //        throw new ArgumentException("Can't be an empty string.", "shopName");
        //    if (apiKey.Length == 0)
        //        throw new ArgumentException("Make sure you have this in your config file.", "apiKey");
        //    if (secret.Length == 0)
        //        throw new ArgumentException("Make sure you have this in your config file.", "secret");

        //    if (shopName.Contains("."))
        //        throw new ArgumentException("make sure that the shop name parameter is the only the subdomain part of the myshopify.com url.", "shopName");

        //    this._shopName = shopName;
        //    this._apiKey = apiKey;
        //    this._secret = secret;
        //}

        /// <summary>
        /// Get the URL required by you to redirect the User to in which they will be 
        /// presented with the ability to grant access to your app with the specified scope
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        private string GetAuthorizationURL(string redirectUrl = null)
        {
            var authURL = new StringBuilder();

            if (! BreezeAPIPath.EndsWith("/"))
            {
                BreezeAPIPath += "/"; 
            }

            authURL.AppendFormat(BreezeAPIPath);
            authURL.AppendFormat("token");

            //if (scope != null && scope.Length > 0)
            //{
            //    string commaSeperatedScope = String.Join(",", scope);
            //    if (!String.IsNullOrEmpty(commaSeperatedScope))
            //        authURL.AppendFormat("&scope={0}", HttpUtility.UrlEncode(commaSeperatedScope));
            //}

            //if (redirectUrl != null && redirectUrl.Length > 0)
            //{
            //    authURL.AppendFormat("&redirect_uri={0}", HttpUtility.UrlEncode(redirectUrl));
            //}

            return authURL.ToString();
        }

        /// <summary>
        /// After the shop owner has authorized your app, Shopify will give you a code.
        /// Use this code to get your authorization state that you will use to make API calls
        /// </summary>
        /// <param name="code">a code given to you by shopify</param>
        /// <returns>Authorization state needed by the API client to make API calls</returns>
        /// 
        public AuthorisationState AuthorizeClient(string user, string password)
        { 
            var str = Base64Encode(user+":"+password);
            return AuthorizeClient(str);
        }
        public AuthorisationState AuthorizeClient(string encodeAuthorisation)
        {
            string url = (BreezeAPIPath.EndsWith("/") ? BreezeAPIPath : (BreezeAPIPath += "/")) + "/json/"  ; // hard code to json to get the Auth_token.
            string endPoint = ConfigurationManager.AppSettings["BreezeAPI.TokenEndPoint"];
            url += endPoint; 
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(url);
            authRequest.Headers.Add(Authorisation, encodeAuthorisation);                 
            authRequest.Method = "GET";

            ////authRequest.ContentType = "application/x-www-form-urlencoded";
            //using (var ms = new MemoryStream())
            //{
            //    using (var writer = new StreamWriter(authRequest.GetRequestStream()))
            //    {
            //        writer.Write(postBody);
            //        writer.Close();
            //    }
            //}
            string ErrorMsg = string.Empty; 
            try
            {
                var response = (HttpWebResponse)authRequest.GetResponse();
                string result = null;

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    result = sr.ReadToEnd();
                    sr.Close();
                }

                if (!String.IsNullOrEmpty(result))
                {
                    // it's JSON so decode it

                    var token = JsonConvert.DeserializeObject<IList<tokenClass>>(result).FirstOrDefault();

                    if (token != null)
                    {
                        var state = new AuthorisationState
                        {
                            Auth_Token = token.token,
                            AuthorisationCode = encodeAuthorisation,
                            isAuthorised = false
                        };

                        state.isAuthorised = isAuthoriseSuccess(state); 
                        return state; 
                    }
                    else
                    {
                        ErrorMsg = "No token was returned."; 
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
            }

            return new AuthorisationState() { AuthorisationCode = encodeAuthorisation, isAuthorised = false, ErrorMsg = ErrorMsg };
        }

        public bool isAuthoriseSuccess(AuthorisationState state)
        {
            string url = (BreezeAPIPath.EndsWith("/") ? BreezeAPIPath : (BreezeAPIPath += "/")) + "/json/"; // hard code to json to get the Auth_token.
            string endPoint = ConfigurationManager.AppSettings["BreezeAPI.TimestampEndPoint"];
            url += endPoint;
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(url);
            authRequest.Headers.Add(Authorisation, state.AuthorisationCode);
            authRequest.Headers.Add(AuthToken, state.Auth_Token);
            authRequest.Method = "GET";
            try
            {
                var response = (HttpWebResponse)authRequest.GetResponse();
                string result = null;

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    result = sr.ReadToEnd();
                    sr.Close();
                }

                if (!String.IsNullOrEmpty(result))
                {
                    var timeStamp = JsonConvert.DeserializeObject<TimeStampClass>(result);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true; 
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        class tokenClass
        {
            public string token { get; set; }
        }

        class TimeStampClass
        {
            public DateTime ServerTimeStamp { get; set; }
        }
    }

}

