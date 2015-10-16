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
            var result = (await m_queryExecutor.HandleAsync(new IconQuery { GuidString = id }));
            return result.SingleOrDefault();
        }

        public async Task<IconResult[]> GetIconsAsync()
        {
            var result = (await m_queryExecutor.HandleAsync(new IconQuery ())).ToArray();
            return result;
        }

        public async Task<IconResult> PostIcon(IconCreateRequest icon)
        {
            var guidString = Guid.NewGuid().ToString();
            var iconToBeCreated = new Icon.Icon
            {
                Description = icon.Description,
                GuidString = guidString,
                Height = icon.Height,
                Path = icon.Path,
                Tag = icon.Tag,
                Title = icon.Title,
                Width = icon.Width
            };
            await m_commandExecutor.ExecuteAsync(iconToBeCreated);

            return await FindIconAsync(guidString);
        }

        public async Task DeleteIcon(string id)
        {
            await m_commandExecutor.ExecuteAsync(new DeleteIconCommand{GuidString = id});
        }

        public async Task UpdateIcon(Icon.Icon icon)
        {
            var foundIcon = await FindIconAsync(icon.GuidString);
            if (foundIcon==null)
            {
                throw new Exception("Icon does not exsist in the database");
            }            
            await m_commandExecutor.ExecuteAsync(new UpdateIconCommand { Icon = icon });
        }

        public async Task IncrementDownloads(string id)
        {
            await m_commandExecutor.ExecuteAsync(new IncrementDownloadsCommand { GuidString = id });
        }
    }
}
