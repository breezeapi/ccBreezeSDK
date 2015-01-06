using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;

namespace Datapel.BreezeAPI.SDK.Service
{

    public class ContactListService : BreezeServiceBase<BaseContact>
    {
        public ContactListService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "contactlist";
    }
}
