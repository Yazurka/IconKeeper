using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using IconKeeper.Server.Command;
using IconKeeper.Server.Icon;
using IconKeeper.Server.Query;

namespace IconKeeper.Server.Services
{
    public class IconKeeperService : IIconKeeperService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;

        public IconKeeperService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
        }

        public async Task<IconResult> FindIconAsync(string id)
        {
            var result = (await m_queryExecutor.HandleAsync(new IconQuery { GuidString = id })).ToArray();
            return !result.Any() ? null : result[0];
        }

        public async Task<IconResult[]> GetIconsAsync()
        {
            var result = (await m_queryExecutor.HandleAsync(new IconQuery ())).ToArray();
            return result;
        }

        public async Task<IconResult> PostIcon(Icon.Icon icon)
        {
            var guidString = Guid.NewGuid().ToString();
            icon.GuidString = guidString;
            await m_commandExecutor.ExecuteAsync(icon);

            return await FindIconAsync(guidString);
        }

        public async Task DeleteIcon(string id)
        {
            await m_commandExecutor.ExecuteAsync(new DeleteIconCommand{GuidString = id});
        }

        public async Task<IconResult> UpdateIcon(string id, Icon.Icon icon)
        {
            var foundIcon = await FindIconAsync(id);
            if (foundIcon==null)
            {
                throw new Exception("Icon does not exsist in the database");
            }
            icon.GuidString = id;
            await m_commandExecutor.ExecuteAsync(new UpdateIconCommand { Icon = icon });
            return await FindIconAsync(id);
        }
    }
}
