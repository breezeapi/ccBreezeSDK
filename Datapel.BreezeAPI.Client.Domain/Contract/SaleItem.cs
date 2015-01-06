using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class BaseSaleItem
    {
        public int jobid { get; set; }
        public int lineid { get; set; }
        public int linenumber { get; set; }
        public bool iskititem { get; set; }
        public bool iskitlineitem { get; set; }
        public int kitheaderlineid { get; set; }
        public string linedescription { get; set; }
        public int itemcode { get; set; }
        public string itemname { get; set; }
        public string itemnumber { get; set; }
        public string notes { get; set; }
        public decimal priceinc { get; set; }
        public decimal priceexc { get; set; }
        public decimal quantity { get; set; }
        public string taxcode { get; set; }
        public decimal taxrate { get; set; }
    }

    public class SaleItem : BaseSaleItem
    {
        public int basestockid { get; set; }
        public string jobnote { get; set; }
        public decimal lastcost { get; set; }
        public decimal actualcost { get; set; }
        public decimal standardcost { get; set; }
        public decimal averagecost { get; set; }
        public decimal discounts { get; set; }
        public int borderbasestockid { get; set; }
        public decimal borderquantity { get; set; }
        public decimal borderpriceexc { get; set; }
        public bool isborderline { get; set; }

    }


}
