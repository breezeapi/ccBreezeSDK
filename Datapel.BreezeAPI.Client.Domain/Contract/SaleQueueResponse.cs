using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class SaleQueueResponse : WMSBaseEntity
    {
        public string status { get; set; }
        public string message { get; set; }
        public string resourcelocation { get; set; }
    }

    public class SaleQueueCountResponse
    {
        public int fileCount { get; set; }
    }

}
