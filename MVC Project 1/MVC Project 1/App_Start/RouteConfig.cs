using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Project_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HomeEmp",
                url: "Gaz/Emp",
                defaults: new { controller = "Employee", action = "New", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Home",
                url: "Gaz/Home",
                defaults: new { controller = "Gaz", action = "Show", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "EmptyUrl",
                url: "",
                defaults: new { Controller = "Gaz", action = "Show", id = UrlParameter.Optional });


        }
    }
}
