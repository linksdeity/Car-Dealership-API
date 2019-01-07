using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarDealershipAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;

            jsonSerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //we just want json
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",//added action because there are multiple overloads of the same types
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
    
}
