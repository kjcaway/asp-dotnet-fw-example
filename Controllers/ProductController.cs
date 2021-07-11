using DemoWebApi.DataAccess;
using DemoWebApi.Models;
using System.Linq;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;
using log4net;
using System.Reflection;

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

            logger.Debug("GetAllProducts");

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
            var result = new ApiResult
            {
                version = version,
                result = "OK",
                data = productDA.getProduct(id)
            };

            return Json(result);
        }

        [Route("api/product/save")]
        [HttpPost]
        public JsonResult<ApiResult> SaveProduct([FromBody] Product data)
        {
            var productDA = new ProductDA();
            productDA.saveProduct(data);

            var result = new ApiResult
            {
                version = version,
                result = "OK"
            };
            
            return Json(result);
        }

        [Route("api/product/modify")]
        [HttpPut]
        public JsonResult<ApiResult> ModProduct([FromBody] Product data)
        {
            var productDA = new ProductDA();
            var result = new ApiResult();

            if(productDA.getProduct(data.productId) == null)
            {
                result.version = version;
                result.result = "FAIL";
                result.error = "Not Found Product";

                return Json(result);
            }
            productDA.updateProduct(data);

            result.version = version;
            result.result = "OK";

            return Json(result);
        }

        public class ApiResult
        {
            public string version { get; set; }
            public string result { get; set; }
            public object data {get;set;}
            public object error { get; set; }
        }
    }
}
