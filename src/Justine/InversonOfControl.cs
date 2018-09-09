using Discord.WebSocket;
using Justine.Discord.Connection;
using Justine.Discord.Handlers;
using Justine.Settings;
using Justine.Settings.SystemConfigurationManager;
using Lamar;

namespace Justine
{
    public static class InversionOfControl
    {
        private static Container container;

        public static Container Container
        {
            get
            {
                if(container is null)
                {
                    InitializeContainer();
                }
                return container;
            }
        }

        public static void InitializeContainer()
        {
            container = new Container(c =>
            {
                c.For<JustineSettings>().Use<JustineSystemConfigurationManagerSettings>();
                c.For<CommandHandler>().Use<DiscordCommandHandler>();
                c.ForSingletonOf<ConnectionService>().UseIfNone<DiscordConnectionService>();
                c.ForSingletonOf<DiscordSocketClient>().UseIfNone<DiscordSocketClient>();
            });
        }
    }
}
