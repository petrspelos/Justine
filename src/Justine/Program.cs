using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Justine.Connection;
using Justine.Settings;
using Justine.Settings.SystemConfigurationManager;
using Lamar;

namespace Justine
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var container = new Container(c =>
            {
                c.For<JustineSettings>().Use<JustineSystemConfigurationManagerSettings>();
                c.ForSingletonOf<ConnectionService>().Use<DiscordConnectionService>();
                c.ForSingletonOf<DiscordSocketClient>();
            });

            await container.GetInstance<Justine>().RunAsync();
        }
    }
}
