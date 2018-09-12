using NUnit.Framework;

namespace Justine.Tests
{
    public static class ConstantsTests
    {
        [Test]
        public static void SettingKeyIsConstant()
        {
            Assert.NotNull(Constants.SettingKeyDiscordToken);
        }
    }
}
