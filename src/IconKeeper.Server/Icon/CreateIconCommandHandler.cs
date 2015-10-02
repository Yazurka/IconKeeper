using System.Data;
using System.Threading.Tasks;
using Dapper;
using IconKeeper.Server.Command;
using IconKeeper.Server.Query;

namespace IconKeeper.Server.Icon
{
    public class CreateIconCommandHandler : ICommandHandler<Icon>
    {
        private readonly IDbConnection m_dbConnection;

        public CreateIconCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(Icon command)
        {
            await m_dbConnection.ExecuteAsync(Sql.CreateIcon, command);
        }
    }
}
