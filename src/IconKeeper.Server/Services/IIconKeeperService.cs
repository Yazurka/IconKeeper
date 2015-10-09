using System.Threading.Tasks;
using IconKeeper.Server.Icon;

namespace IconKeeper.Server.Services
{
    public interface IIconKeeperService
    {
        Task<IconResult> FindIconAsync(string guid);
        Task<IconResult[]> GetIconsAsync();
        Task<IconResult> PostIcon(Icon.Icon icon);
        Task DeleteIcon(string id);
        Task<IconResult> UpdateIcon(string id, Icon.Icon icon);
    }
}
