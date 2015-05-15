using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datapel.BreezeAPI.SDK.Client;
using Newtonsoft.Json;
using System.Configuration;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class ReplicateSlaveService: BreezeServiceBase, IDisposable
    {
        public const string ReplicationQueriesSendCount = "ReplicateMaxSendCount"; 

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

            var pgSize = MaxSendCount;            
            var sb = new StringBuilder();
            DataTable ret = null;
            var dtt = dt.Clone();
            for (int i = 0; (i * MaxSendCount) < dt.Rows.Count; i++)
            {
                dtt.Clear();
                dt.AsEnumerable().Skip(i * pgSize).Take(pgSize).CopyToDataTable(dtt, LoadOption.OverwriteChanges);              

                var json = JsonConvert.SerializeObject(dtt, Formatting.Indented);
                json = submitQueries(json);
                if (! ProcessReturnStatus(json, ref ret))
                {
                    break; 
                }
            }

            return ret;
        }

        protected bool ProcessReturnStatus(string json, ref DataTable dt)
        {
            var tempDt = JsonConvert.DeserializeObject(json, (typeof(DataTable))) as DataTable;
            if (dt == null)
            {
                dt = tempDt.Clone();
            }

            tempDt.AsEnumerable().Take(tempDt.Rows.Count).CopyToDataTable(dt, LoadOption.OverwriteChanges); 
            bool ret = (dt.Select("RTQ_MsgStatus < 0").Count() == 0); 

            return ret; 
        }

        protected string submitQueries (string json)
        {
            var query = FILTER_STR_HEADER + "*";
            var path = GenerateGetPath(HttpMethods.GET, query);
            UseCompression = true;
            json = WebClient.Post(path, json).ToString();
            return json;
        }

        protected int MaxSendCount
        {
            get
            {
                var ret = 0; 
                try
                {
                    ret = Convert.ToInt32(ConfigurationManager.AppSettings[ReplicationQueriesSendCount]); 
                }
                catch
                {
                    ret = 0; 
                }
                return ret; 
            }
        }
    }
}
