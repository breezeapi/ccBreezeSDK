using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class StatusService  : BreezeServiceBase, IDisposable
    {
        public StatusService () 
        {
            base.endpoint = "status"; 
        }

        public StatusResponse GetStatus(StatusType statusType, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetStatusFilter(statusType, searchString);

            var ret = Get<StatusResponse>(query);

            return ret; 
        }


    }



}
