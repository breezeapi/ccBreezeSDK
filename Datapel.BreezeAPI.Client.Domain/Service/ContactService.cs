using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{

    public class ContactService : BreezeServiceBase<Contact>
    {
        public ContactService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "contact";

        #region Constant
        
        #endregion

        public IList<Contact> GetContactById(string cardsId)
        {
            if (string.IsNullOrEmpty(cardsId))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetCardIDFilter(cardsId);
            return GetList(query, 0, 0);
        }
    }
}
