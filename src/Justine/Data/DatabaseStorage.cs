using System.Linq;
using Justine.Data.DatabaseContexts;
using Justine.Data.Entities;

namespace Justine.Data
{
    public class DatabaseStorage : DataStorage
    {
        public GlobalUser GetGlobalUser(ulong discordId)
        {
            using(var db = new GlobalUserContext())
            {
                return db.GetByDiscordId(discordId);
            }
        }
    }
}
