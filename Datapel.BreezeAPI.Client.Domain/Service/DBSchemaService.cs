using Datapel.BreezeAPI.SDK.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class DBSchemaService : BreezeServiceBase, IDisposable
    {
        public DBSchemaService()
        {
            base.endpoint = "DBSchema";
        }

        public int GetVersion()
        {
            var query = FILTER_STR_HEADER + "*";
            var path = GenerateGetPath(HttpMethods.GET, query);
            UseCompression = true;
            var json = WebClient.Get(path).ToString();
            int ret = 0; 
            if (! int.TryParse(json, out ret))
            {

            }
            return ret; 
        }
        public int UpgradeDBSchema(int schemaVersion)
        {
            var query = FILTER_STR_HEADER + "*" + "&version=" + schemaVersion.ToString();
            var path = GenerateGetPath(HttpMethods.GET, query);
            UseCompression = true;
            var json = WebClient.Get(path).ToString();
            int ret = 0;
            if (! int.TryParse(json, out ret))
            {

            }
            return ret;
        }
    }
}
