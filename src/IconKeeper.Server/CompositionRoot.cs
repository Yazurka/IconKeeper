using System.Collections.Generic;
using System.Data;
using IconKeeper.Server.Command;
using IconKeeper.Server.Icon;
using IconKeeper.Server.Query;
using IconKeeper.Server.Services;
using LightInject;
using MySql.Data.MySqlClient;

namespace IconKeeper.Server
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IIconKeeperService, IconKeeperService>();

            serviceRegistry.Register<IQueryExecutor>(factory => new QueryExecutor((IServiceFactory)serviceRegistry));
            serviceRegistry.Register<ICommandExecutor>(factory => new CommandExecutor((IServiceFactory)serviceRegistry));
            serviceRegistry.Register<IDbConnection>(factory => CreateMySqlConnection(factory), new PerScopeLifetime());
       

            serviceRegistry.Register<IQueryHandler<IconQuery, IEnumerable<IconResult>>, IconQueryHandler>();
            serviceRegistry.Register<ICommandHandler<Icon.Icon>, CreateIconCommandHandler>();

            serviceRegistry.Register<IConfiguration, AppSettingsConfiguration>(new PerContainerLifetime());
        }

        private static MySqlConnection CreateMySqlConnection(IServiceFactory factory)
        {
            var connection = new MySqlConnection(factory.GetInstance<IConfiguration>().ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
