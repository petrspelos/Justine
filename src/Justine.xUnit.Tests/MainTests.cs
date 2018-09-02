using Xunit;

namespace Justine.Tests
{
    public static class MainTests
    {
        [Fact]
        public static void MainDoesNotThrow_Test()
        {
            Program.Main(new [] {""});
        }
    }
}
