using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace DemoWebApi.filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(ExceptionFilter));

        public override void OnException(HttpActionExecutedContext context)
        {
            // if (context.Exception is BusinessException)
            logger.Error(context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error"),
                ReasonPhrase = "InternalServerError"
            });
        }
    }
}