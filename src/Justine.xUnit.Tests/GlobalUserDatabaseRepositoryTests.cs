using Justine.Data.Entities;
using Justine.Data.Implementations;
using Justine.Data.Interfaces;
using Xunit;

namespace Justine.Tests
{
    public static class GlobalUserDatabaseRepositoryTests
    {
        [Fact]
        public static void GetGlobalUserTest()
        {
            const long expectedReputation = 28;
            const ulong userDiscordId = 666;
            GlobalUserRepository userRepository = GetTestDataStorage();
            
            Assert.True(userRepository.ExistsByDiscordId(userDiscordId));

            var user = userRepository.GetByDiscordId(userDiscordId);

            Assert.Equal(expectedReputation, user.Reputation);
        }

        [Fact]
        public static void GetNonExistentGlobalUserTest()
        {
            const ulong nonExistentId = 1;
            GlobalUserRepository userRepository = GetTestDataStorage();
            
            var user = userRepository.GetByDiscordId(nonExistentId);

            Assert.Null(user);
        }

        [Fact]
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

            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Reputation, actualUser.Reputation);
            Assert.NotEqual(0, expectedUser.Id);
        }

        private static GlobalUserRepository GetTestDataStorage()
        {
            return new GlobalUserdatabaseRepository();
        }
    }
}
