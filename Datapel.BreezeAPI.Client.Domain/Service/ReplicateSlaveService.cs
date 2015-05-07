using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datapel.BreezeAPI.SDK.Client;
using Newtonsoft.Json;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class ReplicateSlaveService: BreezeServiceBase, IDisposable
    {

        public ReplicateSlaveService() 
        {
            base.endpoint = "replicate"; 
        }

        public DataTable PostReplicateQueries(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null; 
            }
            var json =  JsonConvert.SerializeObject(dt, Formatting.Indented); 
            var query = FILTER_STR_HEADER + "*";
            var path = GenerateGetPath(HttpMethods.GET, query);
            UseCompression = true; 
            json = WebClient.Post(path, json).ToString();

            DataTable ret = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            return ret;
        }
    }
}
