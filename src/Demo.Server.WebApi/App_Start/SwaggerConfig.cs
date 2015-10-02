using System.Web.Http;
using Demo.Server.WebApi.App_Start;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Demo.Server.WebApi.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration 
                .EnableSwagger(c => c.SingleApiVersion("v1", "Demo.Server.WebApi"))
                .EnableSwaggerUi();
        }
    }
}
