using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class SaleResponse
    {
        public int id { get; set; }
        public double totalPay { get; set; }
        public int totalQuantity { get; set; }
        public double subtotal { get; set; }
        public double totalDiscount { get; set; }
        public double taxes { get; set; }
        public DateTime date { get; set; }
        public List<SaleProductReponse> products { get; set; }
    }
}
