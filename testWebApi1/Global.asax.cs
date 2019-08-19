using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace testWebApi1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		public static Logger logger = LogManager.GetCurrentClassLogger();

		protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
