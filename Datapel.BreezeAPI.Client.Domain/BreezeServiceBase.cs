using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Client;
using Datapel.BreezeAPI.SDK.Contract;
using Newtonsoft.Json; 
using Newtonsoft.Json.Converters; 


namespace Datapel.BreezeAPI.SDK
{
    public // abstract 
        class BreezeServiceBase<T> : BreezeServiceBase
        where T : WMSBaseEntity
    {
        #region Constructor
        public BreezeServiceBase(string endpoint)
        {
            this.endpoint = endpoint; 
        }
        #endregion
       
        public IList<T> GetList (string query="filter~*",  int page = 0, int pagesize=100)
        {
            var path = GenerateGetPath(HttpMethods.GET, query, page, pagesize); 
            IList<T> list = null;

            try
            {
                var ret = WebClient.Get(path).ToString();
                CheckIfReturnException(ret); 
                list = JsonConvert.DeserializeObject<IList<T>>(ret);
            }
            catch
#if DEBUG
                (Exception ex)
            {
                //throw ex; 
                var test = ex.Message;
            }
#else
            {}
#endif            
            

            return list; 
        }
        public bool Update(string query, T entity)
        {
            return Save(query, entity, "UPDATE");
        }
        public bool Insert(string query, T entity)
        {
            return Save(query, entity, "INSERT");
        }
        private bool Save (string query, T entity, string updateType)
        {
            var path = GenerateGetPath(HttpMethods.POST, query);
            var strContent = JsonConvert.SerializeObject(entity);
            var postRequest = new PostRequest()
            {
                filter = query,
                updatetype = updateType,
                updateObject = strContent
            };
            strContent = JsonConvert.SerializeObject(postRequest);
            
            var ret = WebClient.Post(path, strContent);

            if (ret != null)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        public T GetTypeList(string query="filter~*",  int page = 0, int pagesize=100)
        {
            var path = GenerateGetPath(HttpMethods.GET, query, page, pagesize);
            T list = null;

            try
            {
                var ret = WebClient.Get(path).ToString();
                CheckIfReturnException(ret);
                list = JsonConvert.DeserializeObject<T>(ret);
            }
            catch
#if DEBUG
 (Exception ex)
            {
                //throw ex; 
                var test = ex.Message;
            }
#else
            {}
#endif


            return list; 
        }

    }

    public class BreezeServiceBase
    {
        #region Constant
        public string FILTER_STR_HEADER = "filter~";
        #endregion

        #region Properties
        protected APIAuthorizer _authoriser;
        protected string endpoint;

        public APIClient WebClient { get; internal set; }

        public AuthorisationState State { get; internal set; }
        #endregion

        public void Authorised(string user, string password)
        {
            if (_authoriser == null)
            {
                _authoriser = new APIAuthorizer();
            }
            State = _authoriser.AuthorizeClient(user, password);
            //if (WebClient == null)
            {
                WebClient = new APIClient(State);
            }
        }

        public void Authorised(AuthorisationState state)
        {
            if (state.isAuthorised)
            {
                State = state;
            }
            else
            {
                if (_authoriser == null)
                {
                    _authoriser = new APIAuthorizer();
                }

                State = _authoriser.AuthorizeClient(state.AuthorisationCode);            
            }

            //if (WebClient == null)
            {
                WebClient = new APIClient(State);
            }
        }

        protected string GenerateGetPath(HttpMethods method, string query, int page = 0, int pagesize = 100)
        {
            string path = endpoint;
            string querystring = string.IsNullOrEmpty(query) ? string.Empty : query;
            if (method == HttpMethods.GET)
            {
                querystring += string.IsNullOrEmpty(querystring) ? "" : "&" + "$top=" + pagesize.ToString() + "&" + "$skip=" + page.ToString();
            }
            path += string.IsNullOrEmpty(querystring) ? "" : ("?" + querystring);
            return path;
        }

        protected bool CheckIfReturnException(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return false;
            }

            if (content.StartsWith("["))
            {
                var objList = JsonConvert.DeserializeObject<IList<WMSBaseEntity>>(content);
                foreach (var obj in objList)
                if (obj.exception != null)
                {
                    return true;
                }
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<WMSBaseEntity>(content);
                if (obj.exception != null)
                {
                    return true;
                }
            }

            return false; 
        }

    }


}
