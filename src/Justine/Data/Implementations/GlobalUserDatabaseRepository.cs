using Justine.Data.DatabaseContexts;
using Justine.Data.Entities;
using Justine.Data.Interfaces;

namespace Justine.Data.Implementations
{
    public class GlobalUserdatabaseRepository : GlobalUserRepository
    {
        public void Create(GlobalUser user)
        {
            using(var db = new GlobalUserContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
        }

        public bool ExistsById(ulong id)
        {
            using(var db = new GlobalUserContext())
            {
                return db.ExistsById(id);
            }
        }

        public GlobalUser GetById(ulong id)
        {
            using(var db = new GlobalUserContext())
            {
                return db.GetById(id);
            }
        }
    }
}
