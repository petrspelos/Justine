using Xunit;
using Justine.Data;
using System;
using System.Configuration;

namespace Justine.Tests
{
    public class ConfigTests
    {
        [Fact]
        public void GetNonExistentValueFromConfigTest()
        {
            const string key = "non-existant-key";
            var config = GetNewConfigInstance();
            
            var actual = config.Get(key);

            Assert.Null(actual);
        }

        [Fact]
        public void StoreAndRetrieveValueFromConfigTest()
        {
            var key = GetUniqueKey();
            const string expectedValue = "Hello, Unit Test!";
            var config = GetNewConfigInstance();

            config.Set(key, expectedValue);
            var actual = config.Get(key);
            
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void StoreNewValueInConfigTest()
        {
            var key = GetUniqueKey();
            const string expected = "Message!";
            var config = GetNewConfigInstance();

            config.Set(key, expected);
            var actual = config.Get(key);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OverwriteValueInConfigTest()
        {
            var key = GetUniqueKey();
            const string expectedOldValue = "OLD-VALUE";
            const string expectedNewValue = "NEW-VALUE";
            var config = GetNewConfigInstance();

            config.Set(key, expectedOldValue);
            var actualOldValue = config.Get(key);
            Assert.Equal(expectedOldValue, actualOldValue);
            config.Set(key, expectedNewValue);
            var actualNewValue = config.Get(key);

            Assert.Equal(expectedNewValue, actualNewValue);
        }

        [Fact]
        public void ConfigEditorEditAfterSaveTest()
        {
            var editor = new ConfigEditor();
            var key = GetUniqueKey();
            const string expected = "A";

            editor.CreateSetting(new ConfigSetting(key, expected));
            editor.Save();
            editor.UpdateSetting(new ConfigSetting(key, "B"));

            var actual = ConfigurationManager.AppSettings[key];

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConfigEditorKeyNotFoundExceptionTest()
        {
            var editor = new ConfigEditor();
            var unknownKey = GetUniqueKey();
            Assert.Throws<NullReferenceException>(
                () => editor.UpdateSetting(new ConfigSetting(unknownKey, "Value"))
            );
        }

        [Fact]
        public void ConfigEditorKeyAlreadyExistsAppendTest()
        {
            var editor = new ConfigEditor();
            var key = GetUniqueKey();
            var expected = "Value,Value2";
            editor.CreateSetting(new ConfigSetting(key, "Value"));
            editor.Save();
            editor.CreateSetting(new ConfigSetting(key, "Value2"));
            editor.Save();

            var actual = ConfigurationManager.AppSettings[key];

            Assert.Equal(expected, actual);
        }

        private string GetUniqueKey()
        {
            return $"UnitTest-Key-{DateTime.Now:yyyy-MM-dd-HH:mm:ss.fff}";
        }

        private IJustineConfig GetNewConfigInstance()
        {
            return new JustineConfig();
        }
    }
}
