using Justine.Data.Entities;
using Justine.Data.Interfaces;
using Justine.Services;
using Moq;
using NUnit.Framework;

namespace Justine.Tests.UserIssuesTests
{
    public class UserissuesServiceTests
    {
        private UserIssuesService userIssuesService;

        [OneTimeSetUp]
        public void Setup()
        {
            var issuesRepo = new Mock<UserIssueRepository>().Object;
            userIssuesService = new UserIssuesService(issuesRepo);
        }

        [Test]
        public void CreateNewIssueTest()
        {
            var issue = new UserIssue
            {
                Id = 500,
                UserId = 1,
                Contents = "Hello, World!"
            };

            userIssuesService.NewIssue(issue);
        }
    }
}
