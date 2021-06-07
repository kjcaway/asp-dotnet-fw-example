using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

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
        public HttpResponseMessage Get()
        {
            // file로 다운받아지네...
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "value");
            res.Content = new StringContent("Hello", System.Text.Encoding.Unicode);
            res.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(30)
            };

            return res;
        }
    }
}
