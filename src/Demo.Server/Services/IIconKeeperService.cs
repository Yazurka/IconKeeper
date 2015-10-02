using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Server.Icon;


namespace Demo.Server.Services
{
    public interface IIconKeeperService
    {
        Task<IconResult> FindIconAsync(string guid);
        Task<IconResult[]> GetIconsAsync();
        void PostIcon(IconResult icon);
    }
}
