using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class Inventory : WMSBaseEntity
    {
        public decimal allocatedqty { get; set; }
        public decimal approveqty { get; set; }
        public decimal availqty { get; set; }
        public int basestockid { get; set; }
        public decimal committed { get; set; }
        public decimal intransitqty { get; set; }
        public string itemname { get; set; }
        public string itemnumber { get; set; }
        public int? locationid { get; set; }
        public decimal onhold { get; set; }
        public decimal onorder { get; set; }
        public decimal quantity { get; set; }
        public decimal shippedqty { get; set; }
        public decimal worcommit { get; set; }

    }
}
