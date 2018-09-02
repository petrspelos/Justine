using Justine.Data.Entities;

namespace Justine.Data
{
    public interface DataStorage
    {
        GlobalUser GetGlobalUser(ulong discordId);
        void CreateGlobalUser(GlobalUser user);
        bool GlobalUserExists(ulong discordId);
    }
}
