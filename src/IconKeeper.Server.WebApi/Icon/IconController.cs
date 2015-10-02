using System.Threading.Tasks;
using System.Web.Http;
using IconKeeper.Server.Icon;
using IconKeeper.Server.Services;

namespace IconKeeper.Server.WebApi.Icon
{
    public class IconController : ApiController
    {
        private readonly IIconKeeperService m_demoService;

        public IconController(IIconKeeperService demoService)
        {
            m_demoService = demoService;
        }

        public async Task<IconResult> Get(string id)
        {
            var result = await m_demoService.FindIconAsync(id).ConfigureAwait(continueOnCapturedContext: false);
            return result;
        }

        public async Task<IconResult[]> Get()
        {
            var result = await m_demoService.GetIconsAsync().ConfigureAwait(continueOnCapturedContext: false);
            return result;
        }
       
        public async Task<IHttpActionResult> Post([FromBody] Server.Icon.Icon icon)
        {
            var result = await m_demoService.PostIcon(icon);

            return Created(CreateResourceLink(result.GuidString), result);
        }

        private string CreateResourceLink<T>(T id)
        {
            return Url.Link("API Default", new { id });
        }
    }
}
