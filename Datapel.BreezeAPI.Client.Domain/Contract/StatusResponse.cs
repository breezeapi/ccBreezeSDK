using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class StatusResponse : WMSBaseEntity
    {        
        public string urn { get; set; }
        public string reference { get; set; }
        public int? statusid { get; set; }
        public string statusvalue { get; set; }
        public string dateofpick { get; set; }
        public string dateofpack { get; set; }
        public string dateofship { get; set; }
        public string dateofclose { get; set; }
        public string shipvia { get; set; }
        public string shipservice { get; set; }
        public string shiptype { get; set; }
        public string shipreference { get; set; }
        public decimal? shipweight { get; set; }
        public decimal? shipcubic { get; set; }
        public int? shiparticles { get; set; }
        public string shipdoc { get; set; }
        public string prn { get; set; }
    }
}
