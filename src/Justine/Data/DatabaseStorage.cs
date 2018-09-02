using System.Linq;
using Justine.Data.DatabaseContexts;
using Justine.Data.Entities;

namespace Justine.Data
{
    public class DatabaseStorage : DataStorage
    {
        public void CreateGlobalUser(GlobalUser user)
        {
            using(var db = new GlobalUserContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
        }

        public GlobalUser GetGlobalUser(ulong discordId)
        {
            using(var db = new GlobalUserContext())
            {
                return db.GetByDiscordId(discordId);
            }
        }

        public bool GlobalUserExists(ulong discordId)
        {
            using(var db = new GlobalUserContext())
            {
                return db.ExistsByDiscordId(discordId);
            }
        }
    }
}
