using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace Justine.Discord.Handlers
{
    public class DiscordMessageHandler : MessageHandler
    {
        private readonly DiscordSocketClient client;
        private readonly TutorialServerMessageHandler tutorialServerMessageHandler;

        public DiscordMessageHandler(
            DiscordSocketClient client, 
            TutorialServerMessageHandler tutorialServerMessageHandler
            )
        {
            this.client = client;
            this.tutorialServerMessageHandler = tutorialServerMessageHandler;
        }

        public void Initialize()
        {
            client.MessageReceived += HandleMessage;
        }

        private async Task HandleMessage(SocketMessage s)
        {
            if (!(s is SocketUserMessage msg)) return;
            if (msg.Channel is SocketDMChannel) return;            
            
            var context = new SocketCommandContext(client, msg);

            if(context.Guild.Id == Constants.TutorialServerId)
            {
                await tutorialServerMessageHandler.HandleMessage(context);
            }
        }
    }
}
