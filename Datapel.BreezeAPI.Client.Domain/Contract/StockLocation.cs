﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public class StockLocation
    {
        public string location { get; set; }
        public decimal quantity { get; set; }
        public string brn { get; set; }
        public int lot { get; set; }
        public string bin { get; set; }
        public decimal onhold { get; set; }
        public DateTime expirydate { get; set; }
    }
}
