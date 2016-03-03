using System.Web.Http;

using Swashbuckle.Application;

using UnitService.RESTfulService;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace UnitService.RESTfulService
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(
                c =>
                {
                    c.SingleApiVersion("v1", "Unit RESTful Service");
                    c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\App.xml");
                }).EnableSwaggerUi();
        }
    }
}