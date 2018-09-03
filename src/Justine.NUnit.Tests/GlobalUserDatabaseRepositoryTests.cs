using Justine.Data.Entities;
using Justine.Data.Implementations;
using Justine.Data.Interfaces;
using NUnit.Framework;

namespace Justine.Tests
{
    public static class GlobalUserDatabaseRepositoryTests
    {
        [Test]
        public static void GetGlobalUserTest()
        {
            const long expectedReputation = 28;
            const ulong userDiscordId = 666;
            GlobalUserRepository userRepository = GetTestDataStorage();
            
            Assert.True(userRepository.ExistsByDiscordId(userDiscordId));

            var user = userRepository.GetByDiscordId(userDiscordId);

            Assert.AreEqual(expectedReputation, user.Reputation);
        }

        [Test]
        public static void GetNonExistentGlobalUserTest()
        {
            const ulong nonExistentId = 1;
            GlobalUserRepository userRepository = GetTestDataStorage();
            
            var user = userRepository.GetByDiscordId(nonExistentId);

            Assert.IsNull(user);
        }

        [Test]
        public static void CreateAndRetrieveGlobalUserTest()
        {
            const ulong userDiscordId = 100;
            const long expectedReputation = 456;
            GlobalUserRepository userRepository = GetTestDataStorage();
            var expectedUser = new GlobalUser {
                DiscordId = userDiscordId,
                Reputation = expectedReputation
            };

            Assert.False(userRepository.ExistsByDiscordId(userDiscordId));

            userRepository.Create(expectedUser);

            Assert.True(userRepository.ExistsByDiscordId(userDiscordId));

            var actualUser = userRepository.GetByDiscordId(userDiscordId);

            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Reputation, actualUser.Reputation);
            Assert.Greater(expectedUser.Id, 0);
        }

        private static GlobalUserRepository GetTestDataStorage()
        {
            return new GlobalUserdatabaseRepository();
        }
    }
}
