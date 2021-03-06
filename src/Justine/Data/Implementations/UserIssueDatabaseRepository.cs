using Justine.Data.Interfaces;
using Justine.Data.Entities;
using Justine.Data.DatabaseContexts;
using System;

namespace Justine.Data.Implementations
{
    public class UserIssueDatabaseRepository : UserIssueRepository
    {
        public void Add(UserIssue issue)
        {
            using(var db = new UserIssueContext())
            {
                db.CreateIssue(issue);
            }
        }

        public UserIssue GetByMessageId(ulong id)
        {
            using(var db = new UserIssueContext())
            {
                return db.GetByMessageId(id);
            }
        }

        public UserIssue GetByUserId(ulong id)
        {
            using(var db = new UserIssueContext())
            {
                return db.GetByUserId(id);
            }
        }

        public void Modify(UserIssue issue, Action<UserIssue> changes)
        {
            changes.Invoke(issue);
            
            using(var db = new UserIssueContext())
            {
                
                db.UpdateIssue(issue);
            }
        }
    }
}
