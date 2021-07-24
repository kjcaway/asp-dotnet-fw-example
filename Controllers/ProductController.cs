using DemoWebApi.DataAccess;
using DemoWebApi.Models;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;
using log4net;
using System.Reflection;
using Newtonsoft.Json;
using DemoWebApi.Dto;
using DemoWebApi.Dto.Product;
using DemoWebApi.Exceptions;

namespace DemoWebApi.Controllers
{
    public class ProductController : ApiController
    {
        readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        readonly string version = WebConfigurationManager.AppSettings["VERSION"].ToString();

        /*Product[] products = new Product[]
        {
            new Product { productId = 1, name = "Tomato Soup", category = "Groceries", price = 1 },
            new Product { productId = 2, name = "Yo-yo", category = "Toys", price = 3.75M },
            new Product { productId = 3, name = "Hammer", category = "Hardware", price = 16.99M }
        };*/

        /** /api/product/ **/
        public JsonResult<ApiResult> GetAllProducts()
        {
            var productDA = new ProductDA();
            var products = productDA.getProductList();

            // System.Console.WriteLine(products);
            // System.Diagnostics.Trace.WriteLine(products);

            return Json(new ApiResult
            {
                version = version,
                result = "SUCCESS",
                data = products
            });
        }

        /*
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.productId == id);
            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }*/

        /** /api/product/{id} **/
        public JsonResult<ApiResult> GetProduct(int id)
        {
            var productDA = new ProductDA();

            return Json(new ApiResult
            {
                version = version,
                result = "OK",
                data = productDA.getProduct(id)
            });
        }

        [Route("api/product/save")]
        [HttpPost]
        public JsonResult<ApiResult> SaveProduct([FromBody] ProductReq data)
        {
            var productDA = new ProductDA();
            productDA.saveProduct(new Product(data));
            
            return Json(new ApiResult
            {
                version = version,
                result = "OK"
            });
        }

        [Route("api/product/modify")]
        [HttpPut]
        public JsonResult<ApiResult> ModProduct([FromBody] ProductReq data)
        {
            var productDA = new ProductDA();

            if(productDA.getProduct(data.productId) == null)
            {
                throw new NotFoundProductException();
            }
            productDA.updateProduct(new Product(data));

            return Json(new ApiResult
            {
                version = version,
                result = "OK"
            });
        }
    }
}
