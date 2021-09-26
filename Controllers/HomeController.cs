using DemoWebApi.Dto;
using DemoWebApi.Exceptions;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;


namespace DemoWebApi.Controllers
{
    public class HomeController: ApiController
    {
        readonly string version = WebConfigurationManager.AppSettings["VERSION"].ToString();

        [Route("api/home/")]
        [HttpGet]
        public JsonResult<ApiResult> Index()
        {
            HttpContext context = HttpContext.Current;

            context.AddError(new BaseException("New Exception #2"));

            context.Response.Close();

            return Json(new ApiResult
            {
                version = version,
                result = "OK"
            });
        }
    }
}