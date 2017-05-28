using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloWorld
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.config");
            routes.MapRoute(
                name:"Home",
                url:"Home/Home",
                defaults: new {controller = "Home", action ="GotoHome",id=UrlParameter.Optional }
                );

            routes.MapRoute(
              name: "EmptyURL",
              url: "",
              defaults: new { controller = "Home", action = "GotoHome", id = UrlParameter.Optional }
              );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
