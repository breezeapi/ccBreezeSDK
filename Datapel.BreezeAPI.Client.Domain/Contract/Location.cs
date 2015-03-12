using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class Location : WMSBaseEntity
    {
        public string cardidentification { get; set; }
        public string comment { get; set; }
        public string contact { get; set; }
        public int contactid { get; set; }
        public int locationsid { get; set; }
        public string description { get; set; }
        public bool isconsignment { get; set; }
        public bool isinactive { get; set; }
        public bool islocked { get; set; }        
        public int remoteid { get; set; }
        public string metadata { get; set; }
    }
}
