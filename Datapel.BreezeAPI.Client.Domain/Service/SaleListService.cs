﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datapel.BreezeAPI.SDK.Contract;
using Datapel.BreezeAPI.SDK.Helper;

namespace Datapel.BreezeAPI.SDK.Service
{
    public class SaleListService : BreezeServiceBase<BaseSale>
    {
        public SaleListService()
            : base(ENDPOINT)
        { }
        private const string ENDPOINT = "saleslist";

        public IList<BaseSale> GetSaleListByMYOBCardId(string cardId)
        {
            if (string.IsNullOrEmpty(cardId))
                return null;

            var query = FILTER_STR_HEADER + FilterHelper.GetMYOBCardIDFilter(cardId);
            return GetList(query, 0, 0);      
        }

        public IList<BaseSale> GetSaleListOrder(string query="filter~*", SaleQueryType qType= SaleQueryType.ALLSALES)
        {
            if (qType != SaleQueryType.ALLSALES)
            {
                query += "&QUERYTYPE=" + qType.ToString();
            }

            var ret = Get<SaleList>(query);

            return ret.orders; 
        }


    }

    public enum SaleQueryType
    {
        ALLSALES,
        SHIPPED,
        BACKORDER,
        RETURNED,
        INPROGRESS,
        QUOTES
    }
}
