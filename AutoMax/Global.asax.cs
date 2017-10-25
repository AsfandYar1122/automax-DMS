using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutoMax
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                Server.Transfer("~/Error/Index");
            }
            else
            {
                if (exc is HttpException)
                {
                    string message = exc.Message;
                    if(message.StartsWith("A public action method ") && message.Contains("was not found on controller"))
                    {
                        Response.Redirect("~/Error/NotFound");
                    }
                }
            }           
        }
        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();
                if (Response.StatusCode == 404)
                {
                    Response.Redirect("~/Error/NotFound");
                }
            }
        }
    }
}
