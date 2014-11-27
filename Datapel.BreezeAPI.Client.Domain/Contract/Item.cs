using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class Item : WMSBaseEntity
    {
        public int basestockid { get; set; }
        public DateTime? timeStamp { get; set; }
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public string notes { get; set; }
        public decimal price { get; set; }
        public decimal priceinc { get; set; }
        public string taxcode { get; set; }
        public decimal taxrate { get; set; }
        public decimal stockonhand { get; set; }
        public decimal stockonhold { get; set; }
        public decimal stockonshelf { get; set; }
        public bool isactive { get; set; }
        public decimal minimumreorderlevel { get; set; }
        public decimal defaultreorderquantity { get; set; }
        public int primarysuppliercardid { get; set; }
        public string primarysupplieritemcode { get; set; }
        public string customfield1 { get; set; }
        public string customfield2 { get; set; }
        public string customfield3 { get; set; }
        public int? customlist1 { get; set; }
        public int? customlist2 { get; set; }
        public int? customlist3 { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string udf3 { get; set; }
        public string udf4 { get; set; }
        public string udf5 { get; set; }
        public string udf6 { get; set; }
        public string udf7 { get; set; }
        public string udf8 { get; set; }
        public string udf9 { get; set; }
        public string udf10 { get; set; }
        public string udf11 { get; set; }
        public string udf12 { get; set; }
        public string udf13 { get; set; }
        public string udf14 { get; set; }
        public string udf15 { get; set; }
        public string udf16 { get; set; }
        public string udf17 { get; set; }
        public string udf18 { get; set; }
        public string udf19 { get; set; }
        public string udf20 { get; set; }
        public string udf21 { get; set; }
        public string udf22 { get; set; }
        public string udf23 { get; set; }
        public string udf24 { get; set; }
        public string buyingunitofmeasure { get; set; }
        public int buyingunit { get; set; }
        public string sellingunitofmeasure { get; set; }
        public string sellingunit { get; set; }
        public bool isbought { get; set; }
        public bool issold { get; set; }
        public bool isinventoried { get; set; }
        public bool isbatchtracked { get; set; }
        public decimal lastcost { get; set; }
        public decimal averagecost { get; set; }
        public decimal standardcost { get; set; }
        public IList<StockLocation> stocklocationlist { get; set; }
        // "stockattachmentlist": null,        
    }
}
