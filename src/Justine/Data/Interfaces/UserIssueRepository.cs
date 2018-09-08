using System;
using Justine.Data.Entities;

namespace Justine.Data.Interfaces
{
    public interface UserIssueRepository
    {
        UserIssue GetByUserId(ulong id);
        UserIssue GetByMessageId(ulong id);
        void Add(UserIssue issue);
        void Modify(UserIssue issue, Action<UserIssue> changes);
    }
}
