using System.Linq;
using System.Threading.Tasks;
using IconKeeper.Server.Icon;
using IconKeeper.Server.Query;

namespace IconKeeper.Server.Services
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
