using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class StockLocation : WMSBaseEntity
    {
        public string location { get; set; }
        public decimal quantity { get; set; }
        public string brn { get; set; }
        public int lot { get; set; }
        public string bin { get; set; }
        public decimal onhold { get; set; }
        public DateTime expirydate { get; set; }        
        public string stocklocation { get; set; }
        public string itemnumber { get; set; }
        public string basestockid { get; set; }
        public string locationid { get; set; }
        public string expireat { get; set; }
        public int batchlistid { get; set; }
        public int binid { get; set; }
        public string bindescription { get; set; }
    }
}
