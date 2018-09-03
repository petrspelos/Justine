using NUnit.Framework;

namespace Justine.Tests
{
    public static class MainTests
    {
        [Test]
        public static void MainDoesNotThrow_Test()
        {
            Program.Main(new [] {""});
        }
    }
}
