using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Client;
using Newtonsoft.Json;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class SaleQueueService : BreezeServiceBase, IDisposable
    {
        public SaleQueueService ()
        {
            base.endpoint = "salesqueue"; 
        }

        public SaleQueueResponse SubmitSaleXML(string xmlString)
        {
            var query = FILTER_STR_HEADER;
            var path = GenerateGetPath(HttpMethods.POST, query);
            var strContent = xmlString;
            //var postRequest = new PostRequest()
            //{
            //    filter = query,
            //    updatetype = PostUpdateType.INSERT.ToString(),
            //    updateObject = strContent
            //};
            //strContent = JsonConvert.SerializeObject(postRequest);
            WebClient.ReturnType = BreezeReturnType.xml; 
            var ret = WebClient.Post(path, strContent).ToString();
            return DeserializeObject<SaleQueueResponse>(ret); 
        }

        public SaleQueueCountResponse FlushXML () 
        {
            SaleQueueCountResponse ret = null; 
            using (var service = new SaleQueueCountService())
            {
                service.Authorised(State);
                ret = service.FlushXMLFile(); 
            }
            return ret; 
        }

    }

    public class SaleQueueCountService : BreezeServiceBase, IDisposable
    {
        public SaleQueueCountService()
        {
            base.endpoint = "salesqueuecount";
        }

        public SaleQueueCountResponse FlushXMLFile()
        {
            var query = FILTER_STR_HEADER + "FLUSH_WAIT" ;
            var ret = Get<SaleQueueCountResponse>(query);
            return ret; 
        }

    }

}
