using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class ProductRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int discount { get; set; }
        public string imageUrl { get; set; }
        public int Category { get; set; }
    }
}
