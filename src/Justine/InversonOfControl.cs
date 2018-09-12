using Discord.WebSocket;
using Justine.Data.Implementations;
using Justine.Data.Interfaces;
using Justine.Discord.Connection;
using Justine.Discord.Handlers;
using Justine.Discord.Providers;
using Justine.Services;
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
                return GetOrInitContainer();
            }
        }

        private static Container GetOrInitContainer()
        {
            if(container is null)
            {
                InitializeContainer();
            }

            return container;
        }

        public static void InitializeContainer()
        {
            container = new Container(c =>
            {
                c.For<JustineSettings>().Use<JustineSystemConfigurationManagerSettings>();
                c.For<CommandHandler>().Use<DiscordCommandHandler>();
                c.For<MessageHandler>().Use<DiscordMessageHandler>();
                c.For<UserIssueRepository>().Use<UserIssueDatabaseRepository>();
                c.For<UserIssuesService>().UseIfNone<UserIssuesService>();
                c.ForSingletonOf<ConnectionService>().UseIfNone<DiscordConnectionService>();
                c.ForSingletonOf<DiscordSocketClient>().UseIfNone<DiscordSocketClient>();
            });
        }
    }
}
