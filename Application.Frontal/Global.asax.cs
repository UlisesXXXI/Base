using Application.Frontal.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Application.Frontal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected async void Application_Start()
        {
            DatosInicialesConfiguracion.Load();
            
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            Response.Clear();

            HttpException httpException = ex as HttpException;
            
            
        }
    }
}
