using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebApi.Dto.Product
{
    public class ProductReq
    {
        public int productId { get; set; }
        [Required]
        public string name { get; set; }
        [Required, StringLength(10)]
        public string category { get; set; }
        [Range(0, 999)]
        public decimal price { get; set; }
    }
}