using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{    
    public class SaleService : BreezeServiceBase<Sale>
    {
        public SaleService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "sales";

        public IList<Sale> GetSaleByMYOBCardId(string cardId)
        {
            if (string.IsNullOrEmpty(cardId))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetMYOBCardIDFilter(cardId);
            return GetList(query, 0, 0);
        }

        public IList<Sale> GetSaleBySaleId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetSaleIDFilter(id);
            return GetList(query, 0, 0);
        }

        public IList<Sale> GetSaleBySRN (string srn)
        {
            if (string.IsNullOrEmpty(srn))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetSRNFilter(srn);
            return GetList(query, 0, 0);
        }
    }
}
