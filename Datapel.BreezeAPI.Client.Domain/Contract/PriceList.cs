using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class PriceList : WMSBaseEntity
    {
        public string itemname {get; set; }
        public int itemid {get; set; }
        public string itemcode {get; set; }
        public decimal specialprice {get; set; }
        public decimal basesell {get; set; }
        public decimal pricelevela {get; set; }
        public decimal quantitybreaka {get; set; }
        public decimal pricelevelb {get; set; }
        public decimal quantitybreakb {get; set; }
        public decimal pricelevelc {get; set; }
        public decimal quantitybreakc {get; set; }
        public decimal priceleveld {get; set; }
        public decimal quantitybreakd {get; set; }
        public decimal pricelevele {get; set; }
        public decimal quantitybreake {get; set; }
        public decimal pricelevelf {get; set; }
        public decimal quantitybreakf {get; set; }
    }
}
