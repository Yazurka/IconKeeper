using System.Threading.Tasks;
using IconKeeper.Server.Icon;

namespace IconKeeper.Server.Services
{
    public interface IIconKeeperService
    {
        Task<IconResult> FindIconAsync(string guid);
        Task<IconResult[]> GetIconsAsync();
        void PostIcon(IconResult icon);
    }
}
