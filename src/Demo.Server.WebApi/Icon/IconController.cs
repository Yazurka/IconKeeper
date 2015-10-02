using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Demo.Server.Command;
using Demo.Server.Icon;
using Demo.Server.Services;

namespace Demo.Server.WebApi.Icon
{
    public class IconController : ApiController
    {
        private readonly IIconKeeperService m_demoService;
        private readonly ICommandExecutor m_commandExecutor;

        public IconController(IIconKeeperService demoService, ICommandExecutor commandExecutor)
        {
            m_demoService = demoService;
            m_commandExecutor = commandExecutor;
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
            await m_commandExecutor.ExecuteAsync(icon);

            return Created(CreateResourceLink(icon.Guid), icon);
        }

        private string CreateResourceLink<T>(T id)
        {
            return Url.Link("API Default", new { id });
        }
    }
}
