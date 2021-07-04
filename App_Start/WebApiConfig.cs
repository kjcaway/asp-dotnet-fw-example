using DemoWebApi.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;

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

            // SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            // traceWriter.IsVerbose = true;
            // traceWriter.MinimumLevel = TraceLevel.Debug;

            config.Services.Replace(typeof(ITraceWriter), new SimpleTracer());
        }
    }
}
