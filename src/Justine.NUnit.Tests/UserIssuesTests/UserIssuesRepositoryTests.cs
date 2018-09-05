using Justine.Data.Interfaces;
using Justine.Data.Implementations;
using NUnit.Framework;
using Justine.Data.Entities;

namespace Justine.Tests.UserIssuesTests
{
    public class UserIssuesRepositoryTests
    {
        private UserIssueRepository userIssueRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            userIssueRepository = new UserIssueDatabaseRepository();
        }

        [Test]
        public void GetTestIssueFromTestDbByUserIdTest()
        {
            var issue = userIssueRepository.GetByUserId(TestConstants.TestUserId);

            AssertIsTestDbTestEntry(issue);
        }

        [Test]
        public void GetTestIssueFromTestDbByMessageIdTest()
        {
            var issue = userIssueRepository.GetByMessageId(TestConstants.TestUserIssueMessageId);

            AssertIsTestDbTestEntry(issue);
        }

        [Test]
        public void GettingNonExistentUserByUserIdReturnsNullTest()
        {
            var issue = userIssueRepository.GetByUserId(TestConstants.NonExistentId);

            Assert.Null(issue);
        }

        [Test]
        public void GettingNonExistentUserByMessageIdReturnsNullTest()
        {
            var issue = userIssueRepository.GetByMessageId(TestConstants.NonExistentId);

            Assert.Null(issue);
        }

        private static void AssertIsTestDbTestEntry(UserIssue issue)
        {
            Assert.NotNull(issue);
            Assert.AreEqual(TestConstants.TestUserIssueMessageId, issue.Id);
            Assert.AreEqual(TestConstants.TestUserIssueContents, issue.Contents);
        }
    }
}
