using System.Linq;
using System.Threading.Tasks;
using Demo.Server.Icon;
using Demo.Server.Query;

namespace Demo.Server.Services
{
    public class IconKeeperService : IIconKeeperService
    {
        private IQueryExecutor m_queryExecutor;
        public IconKeeperService(IQueryExecutor queryExecutor)
        {
            m_queryExecutor = queryExecutor;
        }

        public async Task<IconResult> FindIconAsync(string id)
        {
            var result = (await m_queryExecutor.HandleAsync(new IconQuery { Guid = id })).ToArray();
            return result[0];
        }

        public async Task<IconResult[]> GetIconsAsync()
        {
            var result = (await m_queryExecutor.HandleAsync(new IconQuery ())).ToArray();
            return result;
        }

        public void PostIcon(IconResult icon)
        {
            
        }
    }
}
