using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyBlog.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Session oluşturulduğunda çalışır
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Herhangi bir request yapıldığında çalışır.
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Uygulamanın herhangi bir yerinde oluşan hata Exception bloğundan önce buraya düşer.

            var ex = Server.GetLastError();
            // ExceptionLogService.Log(ex);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Session bittiğinde çalışır
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // Uygulama herhangi bir nedenden dolayı sonlandığında çalışır.
        }
    }
}
