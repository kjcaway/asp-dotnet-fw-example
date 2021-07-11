using System;
using System.IO;
using System.Web.Http;

namespace DemoWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.xml");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(logPath));

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
