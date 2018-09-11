using System.Threading.Tasks;
using Justine.Discord.Connection;
using Justine.Discord.Handlers;

namespace Justine
{
    public class Justine
    {
        private readonly ConnectionService connectionService;
        private readonly CommandHandler commandHandler;
        private readonly MessageHandler messageHandler;

        public Justine(ConnectionService connectionService, CommandHandler commandHandler, MessageHandler messageHandler)
        {
            this.connectionService = connectionService;
            this.commandHandler = commandHandler;
            this.messageHandler = messageHandler;
        }

        public async Task RunAsync()
        {
            await connectionService.ConnectAsync();
            await commandHandler.InitializeAsync();
            messageHandler.Initialize();
        }
    }
}
