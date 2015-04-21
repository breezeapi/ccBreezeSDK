using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class BaseSale : WMSBaseEntity
    {
        public string comment { get; set; }
        public string currencycode { get; set; }
        public string currencycomment { get; set; }
        public DateTime entrydate { get; set; }
        public decimal freight { get; set; }
        public bool hasreturn { get; set; }
        public string invoicenumber { get; set; }
        public bool isclosedreturn { get; set; }
        public bool ishistoric { get; set; }
        public bool ispurchaseraised { get; set; }
        public bool isreturn { get; set; }
        public string location { get; set; } // may not correct
        public int linkcardrecordid { get; set; }
        public int linksaleid { get; set; }
        public int linkshiptoname { get; set; }
        public int linkshiptorecordid { get; set; }
        public int linkshipmethodid { get; set; }
        public int linktermsid { get; set; }
        public string notes { get; set; }
        public DateTime orderdate { get; set; }
        public decimal paidamount { get; set; }
        public string paymentmethod { get; set; }
        public string paymentnotes { get; set; }
        public string prn { get; set; }
        public int priority { get; set; }
        public DateTime promisedate { get; set; }
        public string purchaseordernumber { get; set; }
        public DateTime purchaseraisedate { get; set; }
        public string returnedsrn { get; set; }
        public DateTime saledate { get; set; }
        public int saleid { get; set; }
        public int status { get; set; }
        public string shippingmethod { get; set; }
        public string shipnote { get; set; }
        public string shiptoaddressline1 { get; set; }
        public string shiptoaddressline2 { get; set; }
        public string shiptoaddressline3 { get; set; }
        public string shiptoaddressline4 { get; set; }
        public string srn { get; set; }
        public decimal subtotal { get; set; }
        public decimal tax { get; set; }
        public string termsmessage { get; set; }
        public DateTime updated { get; set; }
        public IList<BaseSaleItem> saleitemlist { get; set; }
        // public object saleattachmentlist { get; set; }

    }

    public class Sale : BaseSale
    {
        public int locationid { get; set; }
        public string locationname { get; set; }
        public int myobcardrecordid { get; set; }
        public string myobbilltoname { get; set; }
        public int myobsaleid { get; set; }
        public string myobshiptoname { get; set; }
        public int myobshiptorecordid { get; set; }
        public int myobshipmethodid { get; set; }
        public int myobtermsid { get; set; }
        public DateTime updatetime { get; set; }
        public DateTime createdate { get; set; }
        public DateTime createtime { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string udf3 { get; set; }
    }

    public class SaleList
    {
        public IList<BaseSale> orders { get; set; }
        public IList<BaseSale> quotes { get; set; }
        public IList<BaseSale> returns { get; set; }
        public IList<BaseSale> shipped { get; set; }
        public IList<BaseSale> pending { get; set; }
        public IList<BaseSale> backorder { get; set; }
        public IList<BaseSale> recent { get; set; }
    }

}
