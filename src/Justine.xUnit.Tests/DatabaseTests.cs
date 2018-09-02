using Justine.Data;
using Justine.Data.Entities;
using Xunit;

namespace Justine.Tests
{
    public static class DatabaseTests
    {
        [Fact]
        public static void GetGlobalUserTest()
        {
            const long expectedReputation = 28;
            const ulong userDiscordId = 666;
            DataStorage storage = GetTestDataStorage();
            
            Assert.True(storage.GlobalUserExists(userDiscordId));

            var user = storage.GetGlobalUser(userDiscordId);

            Assert.Equal(expectedReputation, user.Reputation);
        }

        [Fact]
        public static void GetNonExistentGlobalUserTest()
        {
            const ulong nonExistentId = 1;
            DataStorage storage = GetTestDataStorage();
            
            var user = storage.GetGlobalUser(nonExistentId);

            Assert.Null(user);
        }

        [Fact]
        public static void CreateAndRetrieveGlobalUserTest()
        {
            const ulong userDiscordId = 100;
            const long expectedReputation = 456;
            DataStorage storage = GetTestDataStorage();
            var expectedUser = new GlobalUser {
                DiscordId = userDiscordId,
                Reputation = expectedReputation
            };

            Assert.False(storage.GlobalUserExists(userDiscordId));

            storage.CreateGlobalUser(expectedUser);

            Assert.True(storage.GlobalUserExists(userDiscordId));

            var actualUser = storage.GetGlobalUser(userDiscordId);

            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Reputation, actualUser.Reputation);
            Assert.NotEqual(expectedUser.Id, default(int));
        }

        private static DataStorage GetTestDataStorage()
        {
            return new DatabaseStorage();
        }
    }
}
