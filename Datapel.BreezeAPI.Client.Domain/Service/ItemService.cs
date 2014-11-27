using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class ItemService : BreezeServiceBase<Item>
    {
        public ItemService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "items"; 

    }
}
