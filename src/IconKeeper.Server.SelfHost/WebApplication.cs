using System;
using IconKeeper.Server.WebApi;
using Microsoft.Owin.Hosting;

namespace IconKeeper.Server.SelfHost
{
   public class WebApplication
    {
        private IDisposable m_application;

        public void Start()
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://localhost:9878"); // 10.0.110.190
            m_application = WebApp.Start<Startup>(startOptions);
        }

        public void Stop()
        {
            m_application.Dispose();
        }
    }
}
