using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class SaleProductReponse
    {
        public int id { get; set; }
        public Guid productId { get; set; }
        public int Quantity { get; set; }
        public double price { get; set; }
        public int discount { get; set; }

    }
}
