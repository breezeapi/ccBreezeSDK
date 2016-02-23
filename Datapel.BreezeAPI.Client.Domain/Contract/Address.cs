using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class Address : BaseAddress
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? AddressID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? AddressListID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? CardRecordID { get; set; }   
     
        public string ChangeControl { get; set; }
        public bool IsMatched { get; set; }
        public string WWW { get; set; }   

    }


    public class BaseAddress :WMSBaseEntity
    {
        public string city { get; set; }
        public string contactname { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public int? location { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string postcode { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string streetline1 { get; set; }
        public string streetline2 { get; set; }
        public string streetline3 { get; set; }
        public string streetline4 { get; set; }
        public string title { get; set; }
        public string website { get; set; }	
    }

}
