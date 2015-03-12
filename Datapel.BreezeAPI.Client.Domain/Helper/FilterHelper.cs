using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Helper
{
    public class FilterHelper
    {
        #region Constant
        const string ADDRESSID_FILTER_TEMPLATE = "AddressID={0}";
        const string BASESTOCKID_FILTER_TEMPLATE = "BaseStockID={0}";
        const string CARDID_FILTER_TEMPLATE = "CardsID={0}";
        const string ITEMNUMBER_FILTER_TEMPLATE = "Itemnumber='{0}'";
        const string ITEMNAME_FILTER_TEMPLATE = "Name='{0}'";
        const string MYOBCARD_FILTER_TEMPLATE = "MYOBCardRecordID='{0}'";
        const string SALEID_FILTER_TEMPLATE = "SalesID={0}";
        const string LOCATIONNAME_FILTER_TEMPLATE = "CardIdentification='{0}'";
        const string LOCACTIONID_FILTER_TEMPLATE = "locationid={0}";
        #endregion

        public static string GetAddressIDFilter(string id)
        {
            return string.Format(ADDRESSID_FILTER_TEMPLATE, id);
        }
        public static string GetBaseStockIDFilter(string id)
        {
            return string.Format(BASESTOCKID_FILTER_TEMPLATE, id);
        }
        public static string GetCardIDFilter(string id)
        {
            return string.Format(CARDID_FILTER_TEMPLATE, id);
        }
        public static string GetItemNumberFilter(string id)
        {
            return string.Format(ITEMNUMBER_FILTER_TEMPLATE, id);
        }
        public static string GetItemNameFilter(string name)
        {
            return string.Format(ITEMNAME_FILTER_TEMPLATE, name);
        }
        public static string GetMYOBCardIDFilter(string id)
        {
            return string.Format(MYOBCARD_FILTER_TEMPLATE, id);
        }
        public static string GetSaleIDFilter(string id)
        {
            return string.Format(SALEID_FILTER_TEMPLATE, id);
        }
        public static string GetLocationNameFilter(string name)
        {
            return string.Format(LOCATIONNAME_FILTER_TEMPLATE, name);
        }
        public static string GetLocationIDFilter(string id)
        {
            return string.Format(LOCACTIONID_FILTER_TEMPLATE, id);
        }
    }
}
