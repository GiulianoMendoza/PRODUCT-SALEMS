using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ProductResponse
    {
        public Guid id { get; set; }  
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int discount { get; set; }
        public string imageUrl { get; set; }
        public Category category { get; set; }


    }

}
