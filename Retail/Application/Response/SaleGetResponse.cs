﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class SaleGetResponse
    {
        public int id { get; set; }
        public double totalPay { get; set; }
        public int totalQuantity { get; set; }
        public DateTime date { get; set; }

    }
}