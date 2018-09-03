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
                DiscordId = 666,
                Reputation = 28
            };

            TestRetrieveExistingGlobalUser(expectedUser);
        }

        [Test]
        public void GetNonExistentGlobalUserTest()
        {
            const ulong nonExistentId = 1;
            
            var user = globalUserRepository.GetByDiscordId(nonExistentId);

            Assert.IsNull(user);
        }

        [Test]
        public void CreateAndRetrieveGlobalUserTest()
        {
            var expectedUser = new GlobalUser {
                DiscordId = 100,
                Reputation = 456
            };

            TestCreateNonExistentGlobalUser(expectedUser);
            TestRetrieveExistingGlobalUser(expectedUser);
        }

        private void TestCreateNonExistentGlobalUser(GlobalUser newUser)
        {
            Assert.False(globalUserRepository.ExistsByDiscordId(newUser.DiscordId));

            globalUserRepository.Create(newUser);

            Assert.True(globalUserRepository.ExistsByDiscordId(newUser.DiscordId));
            Assert.Greater(newUser.Id, 0);
        }

        private void TestRetrieveExistingGlobalUser(GlobalUser expectedUser)
        {
            Assert.True(globalUserRepository.ExistsByDiscordId(expectedUser.DiscordId));

            var actualUser = globalUserRepository.GetByDiscordId(expectedUser.DiscordId);

            Assert.AreEqual(expectedUser.Reputation, actualUser.Reputation);
        }
    }
}
