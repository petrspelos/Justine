using System.Threading.Tasks;

namespace Justine.Discord.Handlers
{
    public interface CommandHandler
    {
        Task InitializeAsync();
    }
}
