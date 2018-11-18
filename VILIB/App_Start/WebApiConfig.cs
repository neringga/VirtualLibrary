using System.Web.Http;
using Unity.WebApi;
using VILIB.Resolvers;

namespace VILIB
{
    delegate HttpConfiguration ConfigDelegate(HttpConfiguration delconfig);

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigDelegate ApiConfigDelegate = delegate (HttpConfiguration delconfig)
            {
                // Web API configuration and services
                delconfig.EnableCors(); //lets call api

                // Web API routes
                delconfig.MapHttpAttributeRoutes();

                return delconfig;
            };

            HttpConfiguration apiConfig = ApiConfigDelegate(config);

            apiConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = UnityConfig.RegisterComponents();
            //apiConfig.DependencyResolver = new UnityResolver(container);\
            apiConfig.DependencyResolver = new UnityDependencyResolver(container);
        }

    }

}