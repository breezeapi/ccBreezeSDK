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
            if (pgSize == 0)
                pgSize = dt.Rows.Count;
            IEnumerable<DataRow> drResult; 
            for (int i = 0; (i * pgSize) < dt.Rows.Count; i++)
            {
                dtt.Clear();
                drResult =  dt.AsEnumerable().Skip(i * pgSize).Take(pgSize);
                dtt = drResult.CopyToDataTable(); //dtt, LoadOption.OverwriteChanges);

                var json = JsonConvert.SerializeObject(dtt, Formatting.Indented);
                json = submitQueries(json);
                if (! ProcessReturnStatus(json, ref ret))
                {                    
                    break; 
                }
            }

            return ret;
        }

        public DataTable PostReplicateQueries(ReplicationQuery[] arrRQ)
        {
            if (arrRQ == null || arrRQ.Count() == 0)
            {
                return null;
            }

            var pgSize = MaxSendCount;
            //var sb = new StringBuilder();
            DataTable ret = null;
            //var dtt = arrRQ.Clone();
            if (pgSize == 0)
                pgSize = arrRQ.Count();
            
            for (int i = 0; (i * pgSize) < arrRQ.Count(); i+=pgSize)
            {
                var json = GetJsonStringFromArray(arrRQ, i, pgSize); 
                json = submitQueries(json);
                if (!ProcessReturnStatus(json, ref ret))
                {
                    break;
                }
            }

            return ret;
        }

        protected string UploadFile (string filename, UploadFileType fileType, int? timeout =null)
        {
            var query = FILTER_STR_HEADER + "*&UploadFileType=" + fileType.ToString();
            var path = GenerateGetPath(HttpMethods.POST, query);
            return WebClient.UploadFile(path, filename, timeout).ToString();
        }

        public string UploadReplicateData(string filename, int? timeout =null)
        {
            return UploadFile(filename, UploadFileType.ReplicateData, timeout); 
        }

        public string UploadReportForm(string filename)
        {
            return UploadFile(filename, UploadFileType.ReportForm);
        }

        protected string GetJsonStringFromArray(ReplicationQuery[] rq, int start, int count)
        {
            string ret = string.Empty, json = string.Empty ;
            ret = "["; 
            for (var i = start; i < (start + count) ; i++)
            {
                json = JsonConvert.SerializeObject(rq[i], Formatting.Indented);
                if (!string.IsNullOrEmpty(json) && ret != "[")
                {
                    ret += ","; // add json delimiter. 
                }
                ret += json; 

            }
            ret += "]"; // ensure the payload is in json list form. 
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

    public enum UploadFileType
    {
        ReplicateData,
        ReportForm
    }


    public class ReplicationQuery
    {
        public int RTQ_ID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RTQ_MsgSQL { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public int RTQ_SyncTime { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public int RTQ_SyncDate { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public int RTQ_IsSynced { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public int RTQ_MsgStatus { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string RTQ_ErrorMsg { get; set; }
    }

}
