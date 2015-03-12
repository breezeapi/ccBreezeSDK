using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class LocationService: BreezeServiceBase<Location>
    {
        public LocationService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "locations";

        public IList<Location> GetLocationByName(string locationName)
        {
            if (string.IsNullOrEmpty(locationName))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetLocationNameFilter(locationName);
            return GetList(query, 0, 0);
        }
    }
}
