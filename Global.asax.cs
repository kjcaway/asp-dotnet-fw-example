using log4net;
using System;
using System.IO;
using System.Web.Http;

namespace DemoWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebApiApplication));

        protected void Application_Start()
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.xml");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(logPath));

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        /* not working in asp.net 4.7
        void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();

            logger.Error("App_Error", ex);
        }*/
    }
}
