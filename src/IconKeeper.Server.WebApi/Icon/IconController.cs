using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using IconKeeper.Server.Icon;
using IconKeeper.Server.Services;

namespace IconKeeper.Server.WebApi.Icon
{
    public class IconController : ApiController
    {
        private readonly IIconKeeperService m_iconKeeperService;

        public IconController(IIconKeeperService iconKeeperService)
        {
            m_iconKeeperService = iconKeeperService;
        }
     
        public async Task<IconResult> Get(string id)
        {
            var result = await m_iconKeeperService.FindIconAsync(id).ConfigureAwait(continueOnCapturedContext: false);
            return result;
        }
        
        public async Task<IconResult[]> Get()
        {
            var result = await m_iconKeeperService.GetIconsAsync().ConfigureAwait(continueOnCapturedContext: false);
            return result;
        }

        public async Task<IconResult> Post([FromBody] IconCreateRequest icon)
        {
            var result = await m_iconKeeperService.PostIcon(icon);
            return result;
        }
        
        public async Task<IHttpActionResult> Delete(string id)
        {
            await m_iconKeeperService.DeleteIcon(id);
            return Ok();
        }

        public async Task<IHttpActionResult> Put([FromBody] Server.Icon.Icon icon)
        {
            await m_iconKeeperService.UpdateIcon(icon);
            return Ok();
        }

        
        public async Task<IHttpActionResult> PutIncrementRank([FromBody] string id)
        {
            await m_iconKeeperService.IncrementDownloads(id);
            return Ok();
        }
        
    }
}
