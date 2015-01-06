using Datapel.BreezeAPI.SDK.Contract;
using System.Collections.Generic;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class InventoryService : BreezeServiceBase<StockLocation>
    {
        public InventoryService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "inventory";

        public IList<StockLocation> GetInventoryById(string baseStockId)
        {
            if (string.IsNullOrEmpty(baseStockId))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetBaseStockIDFilter(baseStockId);
            return GetList(query, 0, 0);
        }
    }
}
