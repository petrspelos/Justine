using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace Justine.Discord.Handlers
{
    public class DiscordCommandHandler : CommandHandler
    {
        private readonly DiscordSocketClient client;
        private readonly CommandService commandService;

        public DiscordCommandHandler(DiscordSocketClient client, CommandService commandService)
        {
            this.client = client;
            this.commandService = commandService;
        }

        public async Task InitializeAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commandService.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            if (!(s is SocketUserMessage msg))
            {
                return;
            }
            
            var argPos = 0;
            if (msg.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(client, msg);
                await TryRunAsBotCommand(context, argPos).ConfigureAwait(false);
            }
        }

        private async Task TryRunAsBotCommand(SocketCommandContext context, int argPos)
        {
            await commandService.ExecuteAsync(context, argPos, InversionOfControl.Container);
        }
    }
}
