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
       
        public async Task<IHttpActionResult> Post([FromBody] Server.Icon.Icon icon)
        {
            var result = await m_iconKeeperService.PostIcon(icon);

            return Created(CreateResourceLink(result.GuidString), result);
        }
        
        public async Task<IHttpActionResult> Delete(string id)
        {
            await m_iconKeeperService.DeleteIcon(id);
            return Ok();
        }
        
        public async Task<IconResult> Put(string id, [FromBody] Server.Icon.Icon icon)
        {
           var editedIcon = await m_iconKeeperService.UpdateIcon(id, icon);
           return editedIcon;
        }


        //public async Task<IHttpActionResult> Put(string iconGuidString)
        //{
        //    return null;
        //} 
        
        private string CreateResourceLink<T>(T id)
        {
            return Url.Link("API Default", new { id });
        }
    }
}
