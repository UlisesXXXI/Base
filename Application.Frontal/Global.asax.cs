using Application.Frontal.App_Start;
using Application.Infraestructura.Errors;
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
        //Captura de eventos

        //arranque aplicacion
        protected  void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();

            XmlConfigurator.Configure();
            

            
            UnityConfig.RegisterComponents();
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
            DatosInicialesConfiguracion.Load();
        }

        //captura eventos aplicacion
        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            var _error = new CustomError();
            _error.CodigoError = Guid.NewGuid().ToString();


            log.Error(_error.CodigoError, ex);
            log.Error(ex.Message);





            //url = HttpUtility.UrlEncode(url); 

#if !DEBUG
        Response.Redirect("~/Home/Error/}");
#endif




        }
    }
}
