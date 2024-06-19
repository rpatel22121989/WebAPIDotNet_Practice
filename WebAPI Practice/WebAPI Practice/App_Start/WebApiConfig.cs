using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI_Practice.Filters;
using WebAPI_Practice.Handlers;

namespace WebAPI_Practice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //// Route template without {action}
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //// Route template without {action} & one more additional optional route param: userName
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi1",
            //    routeTemplate: "api/{controller}/{id}/{userName}",
            //    defaults: new { id = RouteParameter.Optional, userName = RouteParameter.Optional }
            //);

            // Maps the specified route template and sets default route values.
            config.Routes.MapHttpRoute(
               name: "DefaultApi2", // name of the route to map
               routeTemplate: "api/{controller}/{action}/{id}", // the route template for route
               defaults: new { id = RouteParameter.Optional } // An object that contains default route values.
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi3",
               routeTemplate: "api/{controller}/{action}/{id}/{userName}",
               defaults: new { id = RouteParameter.Optional, userName = RouteParameter.Optional }
            );

            // enable suports for CORS
            config.EnableCors();

            // add filter attribute to the list of filter that apply to all requests served using this HttpConfiguration class instance.
            config.Filters.Add(new CustomActionFilterAttribute());

            config.MessageHandlers.Add(new HttpMethodRestrictionHandler("GET", "POST"));
        }
    }
}
