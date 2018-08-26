using Xunit;

namespace Justine.Tests
{
    public class MainTests
    {
        [Fact]
        public void MainDoesNotThrow_Test()
        {
            Program.Main(new [] {""});
        }
    }
}
