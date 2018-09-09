using System.Threading.Tasks;
using Discord.Commands;

namespace Justine.Discord.CommandModules
{
    public class BasicModule : ModuleBase<SocketCommandContext>
    {
        [Command("hello", RunMode = RunMode.Async)]
        public async Task Hello()
        {
            // do something with a service...
        }
    }
}
