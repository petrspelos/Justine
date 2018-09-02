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

        public bool ExistsByDiscordId(ulong discordId)
        {
            using(var db = new GlobalUserContext())
            {
                return db.ExistsByDiscordId(discordId);
            }
        }

        public GlobalUser GetByDiscordId(ulong discordId)
        {
            using(var db = new GlobalUserContext())
            {
                return db.GetByDiscordId(discordId);
            }
        }
    }
}
