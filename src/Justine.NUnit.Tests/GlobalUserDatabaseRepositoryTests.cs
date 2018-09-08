using Justine.Data.Entities;
using Justine.Data.Implementations;
using Justine.Data.Interfaces;
using NUnit.Framework;

namespace Justine.Tests
{
    public class GlobalUserDatabaseRepositoryTests
    {
        private GlobalUserRepository globalUserRepository;

        [OneTimeSetUp]
        public void SetupTestResources()
        {
            globalUserRepository = new GlobalUserdatabaseRepository();
        }

        [Test]
        public void RetrieveTestUserFromTestDatabase()
        {
            var expectedUser = new GlobalUser 
            {
                Id = TestConstants.TestUserId,
                Reputation = 28
            };

            TestRetrieveExistingGlobalUser(expectedUser);
        }

        [Test]
        public void GetNonExistentGlobalUserTest()
        {
            var user = globalUserRepository.GetById(TestConstants.NonExistentId);

            Assert.IsNull(user);
        }

        [Test]
        public void CreateAndRetrieveGlobalUserTest()
        {
            var expectedUser = new GlobalUser {
                Id = 100,
                Reputation = 456
            };

            TestCreateNonExistentGlobalUser(expectedUser);
            TestRetrieveExistingGlobalUser(expectedUser);
        }

        private void TestCreateNonExistentGlobalUser(GlobalUser newUser)
        {
            Assert.False(globalUserRepository.ExistsById(newUser.Id));

            globalUserRepository.Create(newUser);

            Assert.True(globalUserRepository.ExistsById(newUser.Id));
        }

        private void TestRetrieveExistingGlobalUser(GlobalUser expectedUser)
        {
            Assert.True(globalUserRepository.ExistsById(expectedUser.Id));

            var actualUser = globalUserRepository.GetById(expectedUser.Id);

            Assert.AreEqual(expectedUser.Reputation, actualUser.Reputation);
        }
    }
}
