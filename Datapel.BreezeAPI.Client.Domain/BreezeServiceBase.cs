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
        class BreezeServiceBase<T>
        where T : WMSBaseEntity
    {
        #region Constructor
        public BreezeServiceBase(string endpoint)
        {
            this.endpoint = endpoint; 
        }
        #endregion

        #region Properties
        private APIAuthorizer _authoriser;
        private string endpoint; 

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
            if (_authoriser == null)
            {
                _authoriser = new APIAuthorizer();
            }
            State = _authoriser.AuthorizeClient(state.AuthorisationCode);
            //if (WebClient == null)
            {
                WebClient = new APIClient(State);
            }
        }

        public IList<T> GetList (string query="filter~*",  int page = 0, int pagesize=100)
        {
            var path = GenerateGetPath(HttpMethods.GET, query, page, pagesize); 
            IList<T> list = null;

            try
            {
                var ret = WebClient.Get(path).ToString();
                list = JsonConvert.DeserializeObject<IList<T>>(ret);
            }
            catch
            { }

            return list; 
        }

        private string GenerateGetPath (HttpMethods method,  string query,  int page = 0, int pagesize=100)
        {
            string path = endpoint;
            string querystring = string.IsNullOrEmpty(query)? string.Empty: query;
            if (method == HttpMethods.GET)
            {
                querystring += string.IsNullOrEmpty(querystring) ? "" : "&" + "$top=" + pagesize.ToString() + "&" + "$skip=" + page.ToString();
            }
            path += string.IsNullOrEmpty(querystring) ? "" : ("?" + querystring); 
            return path; 
        }

        public bool Update(string query, T entity)
        {
            return Save(query, entity, "UPDATE");
        }
        public bool INSERT(string query, T entity)
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


    }
}
