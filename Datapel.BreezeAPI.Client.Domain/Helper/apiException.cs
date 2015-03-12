using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Helper
{
    public class apiException
    {
        public string statuscode { get; set; }
        public string exceptiondescription { get; set; }
        public string exceptionstack { get; set; }
    }
}
