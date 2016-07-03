using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace json_webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "Root",
                routeTemplate: "",   // indicates the root URL
                defaults: new { controller = "Json", action = "ProcessJson" }   // the controller action to handle this URL
            );
        }
    }
}
