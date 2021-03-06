﻿using System.Net.Http.Formatting;
using System.Web.Http;
using LightInject;
using Owin;
using Swashbuckle.Application;

namespace IconKeeper.Server.WebApi
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
           

            ConfigureHttpRoutes(config);
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        
            ConfigureSwagger(config);

            app.UseWebApi(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
        private static void ConfigureSwagger(HttpConfiguration config)
        {
            config.EnableSwagger(
                c => c.SingleApiVersion("v1", "IconKeeper").Description("Icon Keeper Web Api"))
                .EnableSwaggerUi(
                    c => c.CustomAsset("index", typeof(Startup).Assembly, "IconKeeper.Server.WebApi.Swagger.index.html"));
        }
        public virtual void Configure(IServiceContainer serviceContainer)
        {
            serviceContainer.RegisterFrom<CompositionRoot>();
        }
        private static void ConfigureHttpRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });   
        }
    }

}
