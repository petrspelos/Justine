using Justine.Data.Entities;
using Justine.Data.Interfaces;

namespace Justine.Services
{
    public class UserIssuesService
    {
        private readonly UserIssueRepository userIssueRepository;

        public UserIssuesService(UserIssueRepository userIssueRepository)
        {
            this.userIssueRepository = userIssueRepository;
        }

        public void NewIssue(UserIssue issue)
        {
            userIssueRepository.Add(issue);
        }
    }
}
