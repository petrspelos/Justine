using Justine.Data.Entities;

namespace Justine.Data.Interfaces
{
    public interface GlobalUserRepository
    {
        GlobalUser GetByDiscordId(ulong discordId);
        void Create(GlobalUser user);
        bool ExistsByDiscordId(ulong discordId);
    }
}
