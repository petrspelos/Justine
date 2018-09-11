using NUnit.Framework;
using Moq;
using Justine.Discord.Connection;
using System.Threading.Tasks;
using Justine.Discord.Handlers;

namespace Justine.Tests
{
    public class JustineTests
    {
        [Test]
        public async Task JustineRunTest()
        {
            var connService = new Mock<ConnectionService>().Object;
            var cmdHandler = new Mock<CommandHandler>().Object;
            var msgHandler = new Mock<MessageHandler>().Object;
            var justine = new Justine(connService, cmdHandler, msgHandler);
            await justine.RunAsync();
        }
    }
}
