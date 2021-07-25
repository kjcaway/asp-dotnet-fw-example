using DemoWebApi.DataAccess;
using DemoWebApi.Models;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;
using log4net;
using System.Reflection;
using DemoWebApi.Dto;
using DemoWebApi.Dto.Product;
using DemoWebApi.Exceptions;
using System.Linq;

namespace DemoWebApi.Controllers
{
    public class ProductController : ApiController
    {
        private IProductDA _productDA;
        readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly string version = WebConfigurationManager.AppSettings["VERSION"].ToString();

        public ProductController(IProductDA productDA)
        {
            _productDA = productDA;
        }

        /** /api/product/ **/
        public JsonResult<ApiResult> GetAllProducts()
        {
            var products = _productDA.getProductList();

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
            return Json(new ApiResult
            {
                version = version,
                result = "OK",
                data = _productDA.getProduct(id)
            });
        }

        [Route("api/product/save")]
        [HttpPost]
        public JsonResult<ApiResult> SaveProduct([FromBody] ProductReq data)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
                throw new BadParamsExeception(error);
            }

            _productDA.saveProduct(new Product(data));
            
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
            if (!ModelState.IsValid)
            {
                var error = ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
                throw new BadParamsExeception(error);
            }

            if(_productDA.getProduct(data.productId) == null)
            {
                throw new NotFoundProductException();
            }
            _productDA.updateProduct(new Product(data));

            return Json(new ApiResult
            {
                version = version,
                result = "OK"
            });
        }
    }
}
