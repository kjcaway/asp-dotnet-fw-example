using DemoWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;

namespace DemoWebApi.Controllers
{
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        // /api/product/
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        // /api/product/{id}
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("api/product/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var version = WebConfigurationManager.AppSettings["VERSION"].ToString();
            var result = new ApiResult
            {
                version = version,
                result = "OK"
            };
            
            return Ok(result);
        }

        [Route("api/product/getJson")]
        [HttpGet]
        public JsonResult<ApiResult> GetJson()
        {
            var version = WebConfigurationManager.AppSettings["VERSION"].ToString();
            var result = new ApiResult
            {
                version = version,
                result = "OK"
            };

            return Json(result);
        }

        public class ApiResult
        {
            public string version { get; set; }
            public string result { get; set; }
        }
    }
}
