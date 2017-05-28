using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ExceptionHandling.Controllers;

namespace ExceptionHandling
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //GlobalFilters.Filters.Add(new CustomAttr());

            HandleErrorAttribute H1 = new HandleErrorAttribute();
            H1.ExceptionType = typeof(DivideByZeroException);
            H1.View = "DError";
            GlobalFilters.Filters.Add(H1);

            HandleErrorAttribute H2 = new HandleErrorAttribute();
            H2.ExceptionType = typeof(NullReferenceException);
            H2.View = "Error";
            GlobalFilters.Filters.Add(H2);

            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
