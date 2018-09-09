using System.Threading.Tasks;
using Justine.Discord.Connection;
using Justine.Discord.Handlers;

namespace Justine
{
    public class Justine
    {
        private readonly ConnectionService connectionService;
        private readonly CommandHandler commandHandler;

        public Justine(ConnectionService connectionService, CommandHandler commandHandler)
        {
            this.connectionService = connectionService;
            this.commandHandler = commandHandler;
        }

        public async Task RunAsync()
        {
            await connectionService.ConnectAsync();
            await commandHandler.InitializeAsync();
        }
    }
}
