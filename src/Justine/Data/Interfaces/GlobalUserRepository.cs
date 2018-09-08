using Justine.Data.Entities;

namespace Justine.Data.Interfaces
{
    public interface GlobalUserRepository
    {
        GlobalUser GetById(ulong id);
        void Create(GlobalUser user);
        bool ExistsById(ulong id);
    }
}
