using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApi.Dto.Product
{
    public class ProductReq
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
    }
}