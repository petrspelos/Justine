using System;
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
        public void GettingNonExistentIssueByUserIdReturnsNullTest()
        {
            var issue = userIssueRepository.GetByUserId(TestConstants.NonExistentId);

            Assert.Null(issue);
        }

        [Test]
        public void GettingNonExistentIssueByMessageIdReturnsNullTest()
        {
            var issue = userIssueRepository.GetByMessageId(TestConstants.NonExistentId);

            Assert.Null(issue);
        }

        [Test]
        public void CreateNewIssueTest()
        {
            var issue = new UserIssue
            {
                Id = 10,
                UserId = 123,
                Contents = "Hello, World!"
            };

            userIssueRepository.Add(issue);

            AssertIssueExists(issue);
        }

        [Test]
        public void CreateAlreadyExistingIssueThrowsTest()
        {
            var issue = new UserIssue
            {
                Id = TestConstants.TestUserIssueMessageId,
                UserId = 111,
                Contents = "Contents..."
            };

            Assert.Throws<ArgumentException>(() => userIssueRepository.Add(issue));
        }

        [Test]
        public void ModifyNewIssueTest()
        {
            const string expectedContents = "Different";
            var issue = new UserIssue
            {
                Id = 112,
                UserId = 113,
                Contents = "Hello, World!"
            };
            userIssueRepository.Add(issue);

            userIssueRepository.Modify(issue, u => u.Contents = expectedContents);
            
            Assert.AreEqual(expectedContents, issue.Contents);
            AssertIssueExists(issue);
        }

        [Test]
        public void ModifyNonExistentThrowsTest()
        {
            var issue = new UserIssue
            {
                Id = TestConstants.NonExistentId,
                UserId = 115,
                Contents = "NON-EXISTENT"
            };

            Assert.Throws<ArgumentException>(
                () => userIssueRepository.Modify(issue, i => i.Contents = "ABC")
            );
        }

        [Test]
        public void RemoveIssueTest()
        {
            var issue = new UserIssue
            {
                Id = 116,
                UserId = 117,
                Contents = "My Cool Issue!" 
            };
            userIssueRepository.Add(issue);
            AssertIssueExists(issue);
            userIssueRepository.RemoveById(116);
            Assert.Null(userIssueRepository.GetByMessageId(116));
        }

        [Test]
        public void RemoveNonExistentIssueThrowsTest()
        {
            Assert.Throws<ArgumentException>(
                () => userIssueRepository.RemoveById(TestConstants.NonExistentId)
            );
        }

        private void AssertIssueExists(UserIssue issue)
        {
            var storedIssueByUser = userIssueRepository.GetByUserId(issue.UserId);
            var storedIssueByMessage = userIssueRepository.GetByMessageId(issue.Id);

            Assert.NotNull(storedIssueByUser);
            Assert.NotNull(storedIssueByMessage);
            Assert.AreSame(storedIssueByMessage, storedIssueByMessage);

            Assert.AreEqual(issue.Contents, storedIssueByUser.Contents);
            Assert.AreEqual(issue.Contents, storedIssueByMessage.Contents);
        }

        private static void AssertIsTestDbTestEntry(UserIssue issue)
        {
            Assert.NotNull(issue);
            Assert.AreEqual(TestConstants.TestUserIssueMessageId, issue.Id);
            Assert.AreEqual(TestConstants.TestUserIssueContents, issue.Contents);
        }
    }
}
