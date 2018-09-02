using Justine.Data;
using Xunit;

namespace Justine.Tests
{
    public static class DatabaseTests
    {
        [Fact]
        public static void GetGlobalUser()
        {
            const long expectedReputation = 28;

            DataStorage storage = GetTestDataStorage();
            var user = storage.GetGlobalUser(666);

            Assert.Equal(expectedReputation, user.Reputation);
        }

        private static DataStorage GetTestDataStorage()
        {
            return new DatabaseStorage();
        }
    }
}
