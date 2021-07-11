using DemoWebApi.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.IO;
using log4net.Config;
using log4net;
using DemoWebApi.filters;

namespace DemoWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 구성 및 서비스

            // Web API 경로
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Exception Filter
            config.Filters.Add(new ExceptionFilter());

            // for logging test
            // SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            // traceWriter.IsVerbose = true;
            // traceWriter.MinimumLevel = TraceLevel.Debug;

            // for custom logging test
            // config.Services.Replace(typeof(ITraceWriter), new SimpleTracer());
        }
    }
}
