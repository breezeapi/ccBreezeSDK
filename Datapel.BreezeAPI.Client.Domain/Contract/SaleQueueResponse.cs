using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Datapel.BreezeAPI.SDK.Contract
{
    [XmlRoot("postresponse")]
    public class SaleQueueResponse : WMSBaseEntity
    {
        [XmlElement("status")]
        public string status { get; set; }
        [XmlElement("message")]
        public string message { get; set; }
        [XmlElement("urn")]
        public string resourcelocation { get; set; }
    }

    public class SaleQueueCountResponse
    {
        public int fileCount { get; set; }
    }

}
