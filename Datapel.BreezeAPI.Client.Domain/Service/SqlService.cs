using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Datapel.BreezeAPI.SDK.Client;
using Datapel.BreezeAPI.SDK.Contract;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class SqlService : BreezeServiceBase, IDisposable
    {

        public SqlService() 
        {
            base.endpoint = "sql"; 
        }

        public string GetSql(string sqlString)
        {
            if (string.IsNullOrEmpty(sqlString))
                return null;

            var query = FILTER_STR_HEADER + sqlString;
            var path = GenerateGetPath(HttpMethods.GET, query);
            var ret = WebClient.Get(path).ToString();            
            return ret; 
        }

        public IList<WebProduct> GetWebProduct()
        {
            var webStoreViewName = ConfigurationManager.AppSettings["WebStore.ViewName"].ToString();

            var sql = string.Format("SELECT * FROM {0};", webStoreViewName);

            var ret = GetSql(sql);

            var itemList = DeserializeObject<IList<WebProduct>>(ret);

            return itemList; 
        }

    }
}
