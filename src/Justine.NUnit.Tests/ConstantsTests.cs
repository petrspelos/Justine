using System;
using NUnit.Framework;

namespace Justine.Tests
{
    public class ConstantsTests
    {
        [Test]
        public void SettingKeyIsConstant()
        {
            Assert.NotNull(Constants.SettingKeyDiscordToken);
        }
    }
}
