using System;
using Demo.Server.WebApi;
using Microsoft.Owin.Hosting;

namespace Demo.Server.SelfHost
{
   public class WebApplication
    {
        private IDisposable m_application;

        public void Start()
        {
            var startOptions = new StartOptions();
            //startOptions.Urls.Add("http://localhost:9876");
            //startOptions.Urls.Add("http://localhost:9878");
            startOptions.Urls.Add("http://10.0.110.190:9878");
            //startOptions.Urls.Add(string.Format("http://{0}:9876", Environment.MachineName));
            m_application = WebApp.Start<Startup>(startOptions);
        }

        public void Stop()
        {
            m_application.Dispose();
        }
    }
}
