using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LightInject;
using LightInject.WebApi;
using System.Web;

using Owin;
using Swashbuckle.Application;


namespace Demo.Server.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = new ServiceContainer();

            Configure(container);
            container.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();
            container.RegisterApiControllers(typeof(Startup).Assembly);
            container.EnableWebApi(config);

           
            var configuration = container.GetInstance<IConfiguration>();

         

        
            ConfigureHttpRoutes(config);
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        
            ConfigureSwagger(config, configuration);

          
            app.UseWebApi(config);
        }
        private static void ConfigureSwagger(HttpConfiguration config, IConfiguration configuration)
        {
            config.EnableSwagger(
                c => c.SingleApiVersion("v1", "Demo").Description("Web Api Demo"))
                .EnableSwaggerUi(
                    c => c.CustomAsset("index", typeof(Startup).Assembly, "Demo.Server.WebApi.Swagger.index.html"));
        }
        public virtual void Configure(IServiceContainer serviceContainer)
        {
            serviceContainer.RegisterFrom<CompositionRoot>();
        }
        private static void ConfigureHttpRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }

}
