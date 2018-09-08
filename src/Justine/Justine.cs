using System.Threading.Tasks;
using Justine.Connection;

namespace Justine
{
    public class Justine
    {
        private readonly ConnectionService connectionService;

        public Justine(ConnectionService connectionService)
        {
            this.connectionService = connectionService;
        }

        public async Task RunAsync()
        {
            await connectionService.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
