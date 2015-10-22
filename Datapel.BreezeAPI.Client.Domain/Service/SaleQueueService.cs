using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Client;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
            return DeserialXML<SaleQueueResponse>(ret); 
        }
        private T DeserialXML<T>(string xmlStr)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlStr))
            {
                return (T)serializer.Deserialize(reader);
            }
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


        public IList<Tuple<string, string>> SplitSalesQueueXML(string xmlString)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            var nodeList = xmlDoc.SelectNodes("/SalesQueueXml/salesQueue/SalesQueue");
            var retList = new List<Tuple<string, string>>(); 

            foreach (XmlNode xn in nodeList)
            {
                //string outData = "<NewDataSet>" + xn["data"].InnerXml + "</NewDataSet>";
                string outData = System.Net.WebUtility.HtmlDecode(xn["data"].InnerXml);
                //if (!outData.StartsWith("<NewDataSet>"))
                //{
                //    outData = "<NewDataSet>" + outData;
                //}
                //if (!outData.EndsWith("</NewDataSet>"))
                //{
                //    outData = "</NewDataSet>" + outData;
                //}
                string fileName = xn["nameOfFile"].InnerText;
                retList.Add(new Tuple<string, string>(fileName, outData)); 
            }
            
            return retList; 
        }
        
        public string GetWITHLOCK ()
        {
            return GetSalesQueue("WITHLOCK");
        }

        public string GetUNLOCK()
        {
            return GetSalesQueue("UNLOCK");
        }

        public string GetDELETE()
        {
            return GetSalesQueue("DELETE");
        }

        /// <summary>
        /// This is a customise GET for salesqueue service. 
        /// </summary>
        /// <param name="action">value: WITHLOCK, DELETE, UNLOCK</param>
        /// <returns></returns>
        internal string GetSalesQueue(string action)
        {
            var query = FILTER_STR_HEADER ;
            if (!string.IsNullOrEmpty(action))
            {
                query += action; 
            }

            var path = GenerateGetPath(HttpMethods.GET, query);
            WebClient.ReturnType = BreezeReturnType.xml;
            var ret = WebClient.Get(path).ToString();
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
