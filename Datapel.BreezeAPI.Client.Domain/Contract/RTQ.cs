using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class RTQ : WMSBaseEntity
    {
        public int RTQ_ID { get; set; }
        public long RTQ_SyncTime { get; set; }
        public long RTQ_SyncDate { get; set; }
        public int RTQ_IsSynced { get; set; }
        public string RTQ_MsgSQL { get; set; }
        public int RTQ_MsgStatus { get; set; }
        public string RTQ_Msg { get; set; }
        public string RTQ_ErrorMsg { get; set; }
    }
}
