using Application.Frontal.App_Start;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Application.Frontal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected  void Application_Start()
        {
            XmlConfigurator.Configure();
            DatosInicialesConfiguracion.Load();

            
            UnityConfig.RegisterComponents();
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error(Guid.NewGuid());
            log.Error(ex.Message);

           
           
            
            
            //url = HttpUtility.UrlEncode(url); 
            
           
            Response.Redirect("~/Home/Error/}");



        }
    }
}
