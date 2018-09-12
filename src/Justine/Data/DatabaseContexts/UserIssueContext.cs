using System;
using System.IO;
using System.Linq;
using Justine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Justine.Data.DatabaseContexts
{
    internal class UserIssueContext : DbContext
    {
        internal DbSet<UserIssue> UserIssue { get; set; }

        internal UserIssue GetByUserId(ulong id)
        {
            return UserIssue.FirstOrDefault(ui => ui.UserId == id);
        }

        internal UserIssue GetByMessageId(ulong id)
        {
            return UserIssue.FirstOrDefault(ui => ui.Id == id);
        }

        internal void CreateIssue(UserIssue issue)
        {
            try
            {
                Add(issue);
                SaveChanges();
            }
            catch(DbUpdateException)
            {
                throw new ArgumentException("User Issue already exists.");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Justine.db");
        }

        internal void UpdateIssue(UserIssue issue)
        {
            try
            {
                Update(issue);
                SaveChanges();
            }
            catch(DbUpdateException)
            {
                throw new ArgumentException("User Issue doesn't exist.");
            }
        }
    }
}
