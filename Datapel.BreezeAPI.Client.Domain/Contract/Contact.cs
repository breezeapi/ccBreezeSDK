using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class BaseContact : WMSBaseEntity
    {
        public int contactid { get; set; }
        public int? linkcardrecordid { get; set; }
        public DateTime createdat { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public bool isindividual { get; set; }
        public bool isinactive { get; set; }
        public bool creditonhold { get; set; }
        public string notes { get; set; }
        public int customlist1 { get; set; }
        public int customlist2 { get; set; }
        public int customlist3 { get; set; }
        public string customfield1 { get; set; }
        public string customfield2 { get; set; }
        public string customfield3 { get; set; }
        public DateTime updatedat { get; set; }
        public IList<BaseAddress> contactaddresslist { get; set; }

    }

    public class Contact : BaseContact
    {   
        public string defaulttaxcode { get; set; }
        public int defaultcontactid { get; set; }
        public string currencycode { get; set; }
        public decimal currentbalance { get; set; }

        public int lastsaledate { get; set; }  // Data is integer so need to change from DateTime to int
        public int lastpaymentdate { get; set; } // Data is integer so need to change from DateTime to int
        public string termsmessage { get; set; }
        public string pricelevel { get; set; }
        public int discountdays { get; set; }
        public int balanceduedays { get; set; }
        public int balanceduedate { get; set; }
        public string cardidentification { get; set; }
        public string contacttype { get; set; }
        public int? companybranchid { get; set; }
        public string companyid { get; set; }
        public string identifiers { get; set; }
        public string defaultshipmethod { get; set; }
        public string paymentdeliverymethod { get; set; }
        public string invoicedeliverymethod { get; set; }
        public decimal creditlimit { get; set; }
        public decimal volumediscount { get; set; }
        public string defaultsalecomment { get; set; }
        public bool usedefaulttaxcode { get; set; }
        public string companytaxid { get; set; }
        public int totalreceivabledays { get; set; }
        public int customersincedate { get; set; }
        public int? timeStamp { get; set; }
    }
}
