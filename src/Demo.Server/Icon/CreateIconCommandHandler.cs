using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Demo.Server.Command;
using Demo.Server.Query;

namespace Demo.Server.Icon
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
            command.Guid = Guid.NewGuid().ToString();
            await m_dbConnection.ExecuteAsync(Sql.CreateIcon, command);
        }
    }
}
