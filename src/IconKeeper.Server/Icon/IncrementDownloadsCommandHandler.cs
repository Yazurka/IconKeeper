using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IconKeeper.Server.Command;
using IconKeeper.Server.Query;

namespace IconKeeper.Server.Icon
{
    public class IncrementDownloadsCommandHandler : ICommandHandler<IncrementDownloadsCommand>
    {
       private readonly IDbConnection m_dbConnection;

       public IncrementDownloadsCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(IncrementDownloadsCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.IncrementDownloads, command);
        }
    }
}
