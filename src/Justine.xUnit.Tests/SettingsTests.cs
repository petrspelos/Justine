using Xunit;
using System;
using Justine.Settings;
using Justine.Settings.SystemConfigurationManager;

namespace Justine.Tests
{
    public class SettingsTests
    {

        [Fact]
        public void StoreNewValueTest()
        {
            const string expected = "Message!";
            var key = GetUniqueKey();
            var settings = GetNewSettings();

            settings.Set(key, expected);
            var actual = settings.Get(key);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StoreAndRetrieveValueTest()
        {
            var key = GetUniqueKey();
            const string expectedValue = "Hello, Unit Test!";
            var settings = GetNewSettings();

            settings.Set(key, expectedValue);
            var actual = settings.Get(key);
            
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void OverwriteValueTest()
        {
            const string expected = "B";
            var settings = GetNewSettings();
            var key = GetUniqueKey();

            settings.Set(key, "A");
            settings.Set(key, expected);
            var actual = settings.Get(key);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNonExistentValueTest()
        {
            const string key = "non-existant-key";
            var settings = GetNewSettings();
            
            var actual = settings.Get(key);

            Assert.Null(actual);
        }

        private string GetUniqueKey()
        {
            return $"UnitTest-Key-{DateTime.Now:yyyy-MM-dd-HH:mm:ss.fff}";
        }

        private JustineSettings GetNewSettings()
        {
            return new JustineSystemConfigurationManagerSettings();
        }
    }
}
