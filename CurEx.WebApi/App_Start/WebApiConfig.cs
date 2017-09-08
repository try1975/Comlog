using System.Web.Http;
using CurEx.WebApi.Logging;

namespace CurEx.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.ParameterBindingRules
            //      .Add(typeof(DateTime?), des => new DateTimeParameterBinding(des));


            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // logging
            config.MessageHandlers.Add(new LogHandler());
        }
    }
}
