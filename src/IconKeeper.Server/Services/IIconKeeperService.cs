using System.Threading.Tasks;
using IconKeeper.Server.Icon;

namespace IconKeeper.Server.Services
{
    public interface IIconKeeperService
    {
        Task<IconResult> FindIconAsync(string guid);
        Task<IconResult[]> GetIconsAsync();
        Task<IconResult> PostIcon(IconCreateRequest icon);
        Task DeleteIcon(string id);
        Task UpdateIcon(Icon.Icon icon);
        Task IncrementDownloads(string id);
    }
}
