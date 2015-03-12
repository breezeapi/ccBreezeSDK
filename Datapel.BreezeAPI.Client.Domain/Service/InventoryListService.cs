using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class InventoryListService : BreezeServiceBase<InventoryList>
    {
        public InventoryListService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "inventorylist";

        public InventoryList GetListByLocationId(string locationId)
        {
            
            if (string.IsNullOrEmpty(locationId) || string.IsNullOrEmpty(locationId))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetLocationIDFilter(locationId);

            return GetTypeList(query);            
        }
    }
}
