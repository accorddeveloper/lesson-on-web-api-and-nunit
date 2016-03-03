namespace UnitService.RESTfulService
{
    using System.Web.Http;

    using Autofac.Integration.WebApi;

    using UnitService.DependencyInjection;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(TypeLookUp.Container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}