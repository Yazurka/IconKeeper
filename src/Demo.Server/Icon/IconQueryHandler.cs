using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Threading.Tasks;

using Demo.Server.Query;

namespace Demo.Server.Icon
{
    public class IconQueryHandler : IQueryHandler<IconQuery, IEnumerable<IconResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public IconQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }
        public async Task<IEnumerable<IconResult>> HandleAsync(IconQuery query)
        {
            if (query.Guid == null)
            {
                var dummyData = await m_dbConnection.QueryAsync<IconResult>(Sql.IconAll);
                return dummyData;
            }
            else
            {
                var dummyData = await m_dbConnection.QueryAsync<IconResult>(Sql.Icon, new{ guid = query.Guid});
                return dummyData;
            }
         
        }
    }
}
