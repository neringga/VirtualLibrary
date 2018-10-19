using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;
using Unity.Mvc5;
using VILIB.Presenters;
using VILIB.Resolvers;

namespace VILIB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(); //lets call api

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = UnityConfig.RegisterComponents();
            config.DependencyResolver = new UnityResolver(container);
        }
    }

}