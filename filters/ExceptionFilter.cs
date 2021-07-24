using DemoWebApi.Exceptions;
using log4net;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Filters;

namespace DemoWebApi.filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(ExceptionFilter));
        
        public override void OnException(HttpActionExecutedContext context)
        {
            if(context.Exception is BaseException)
            {
                HttpStatusCode httpCode = (context.Exception as BaseException).httpCode;
                string jsonStr = JsonConvert.SerializeObject(new { 
                    code = httpCode,
                    message = (context.Exception as BaseException).message 
                });

                throw new HttpResponseException(new HttpResponseMessage(httpCode)
                {
                    Content = new StringContent(jsonStr, Encoding.UTF8, "application/json"),
                    ReasonPhrase = null
                });
            }
            logger.Error(context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error"),
                ReasonPhrase = "InternalServerError"
            });
        }
    }
}