using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Discord.Commands;
using Justine.Discord.Providers;

namespace Justine.Discord.Handlers
{
    public class TutorialServerMessageHandler
    {
        private readonly IEnumerable<ServiceProvider> services;

        public TutorialServerMessageHandler(
            UserIssuesProvider userIssuesProvider
            )
        {
            services = new List<ServiceProvider>
            {
                userIssuesProvider
            }.ToImmutableList();
        }

        internal async Task HandleMessage(SocketCommandContext context)
        {
            foreach(var service in services)
            {
                await service.InvokeByContext(context);
            }
        }
    }
}
