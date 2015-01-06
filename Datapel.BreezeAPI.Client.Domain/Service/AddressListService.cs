using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{

    public class AddressListService : BreezeServiceBase<Address>
    {
        public AddressListService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "addresslist";

        public IList<Address> GetAddressById(string addressId)
        {
            if (string.IsNullOrEmpty(addressId))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetAddressIDFilter(addressId);
            return GetList(query, 0, 0);
        }
    }    
}
