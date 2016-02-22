using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CacheK
{
    public class Starter : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes(new CustomServicesRouteProvider());

            GlobalConfiguration.Configuration.MessageHandlers.Add(new CacheCow.Server.CachingHandler(GlobalConfiguration.Configuration));

            GlobalConfiguration.Configuration.EnsureInitialized();

            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        void Application_End(object sender, EventArgs e)
        {
            // config.EnableCors(new EnableCorsAttribute(corsDomains, "*", "*") { SupportsCredentials = true });



        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
    }
}