using NUnit.Framework;
using Moq;
using Justine.Connection;
using System.Threading.Tasks;

namespace Justine.Tests
{
    public class JustineTests
    {
        [Test]
        public async Task JustineRunTest()
        {
            var connService = new Mock<ConnectionService>().Object;
            var justine = new Justine(connService);
            await justine.RunAsync();
        }
    }
}
