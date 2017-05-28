using EmployeeWebAPI.App_Start;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Models;

namespace EmployeeWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //

            //var cors = new EnableCorsAttribute("http://localhost:1213", "*", "*");
            //config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            IUnityContainer container = new UnityContainer();
            container.RegisterType<Employee, EmpDiscountbyAge>();
            container.RegisterType<Employee, EmpDiscountbySalary>();
            container.RegisterType<Employee, EmpDiscountbyDOJ>();
            //config.DependencyResolver = new MyUnityResolver(container);
        }
    }
}
