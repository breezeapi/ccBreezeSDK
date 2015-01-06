using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class PriceListService : BreezeServiceBase<PriceList>
    {
        public PriceListService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "pricelist";
        
        public IList<PriceList> GetPriceList(string itemNumber, string name)
        {
            if (string.IsNullOrEmpty(itemNumber) || string.IsNullOrEmpty(name))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetItemNameFilter(name) + ", " + FilterHelper.GetItemNumberFilter(itemNumber);
            return GetList(query, 0, 0); 
        }
    }
}
