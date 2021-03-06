﻿using Topshelf;

namespace IconKeeper.Server.SelfHost
{
    class Program
    {
        private static int Main()
        {

            return (int)HostFactory.Run(
                 host =>
                 {
                     host.Service<WebApplication>(
                         service =>
                         {
                             service.ConstructUsing(() => new WebApplication());
                             service.WhenStarted(s => s.Start());
                             service.WhenStopped(s => s.Stop());
                         });
                     host.RunAsLocalSystem();
                     host.SetServiceName("DIPSIconKeeper");
                     host.SetDisplayName("DIPSIconKeeper");
                     host.SetDescription("DIPSIconKeeper Web Server");
                 });
        }
    }
}
