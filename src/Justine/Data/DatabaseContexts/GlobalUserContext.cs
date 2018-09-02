using System;
using System.IO;
using System.Linq;
using Justine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Justine.Data.DatabaseContexts
{
    internal class GlobalUserContext : DbContext
    {
        internal DbSet<GlobalUser> GlobalUser { get; set; }

        internal GlobalUser GetByDiscordId(ulong id)
        {
            return GlobalUser.FirstOrDefault(gu => gu.DiscordId == id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Justine.db");
        }
    }
}
