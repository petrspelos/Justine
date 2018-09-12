using System.Threading.Tasks;
using Discord.Commands;

namespace Justine.Discord.Providers
{
    public interface ServiceProvider
    {
        Task InvokeByContext(SocketCommandContext context);
    }
}
