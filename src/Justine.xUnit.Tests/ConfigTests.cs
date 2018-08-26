using Xunit;
using Justine.Data;
using System;

namespace Justine.Tests
{
    public class ConfigTests
    {
        [Fact]
        public void GetNonExistentValueFromConfigTest()
        {
            const string key = "non-existant-key";
            
            IJustineConfig config = new JustineConfig();
            
            var actual = config.Get(key);

            Assert.Null(actual);
        }

        [Fact]
        public void StoreAndRetrieveValueFromConfigTest()
        {
            var key = $"Unit-Test-Key-{DateTime.Now.ToLongTimeString()}";
            const string expected = "Hello, Unit Test!";
            IJustineConfig config = new JustineConfig();

            config.Set(key, expected);
            var actual = config.Get(key);
            Assert.Equal(expected, actual);
            
            config.Set(key, string.Empty);
            Assert.Equal(string.Empty, config.Get(key));
        }

        [Fact]
        public void StoreNewValueInConfigTest()
        {
            var key = $"Unit-Test-2-Key-{DateTime.Now.ToLongTimeString()}";
            const string expected = "Message!";
            IJustineConfig config = new JustineConfig();

            config.Set(key, expected);
            var actual = config.Get(key);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OverwriteValueInConfigTest()
        {
            var key = $"Unit-Test-3-Key-{DateTime.Now.ToLongTimeString()}";
            const string expected = "NEW-VALUE";
            IJustineConfig config = new JustineConfig();

            config.Set(key, "OLD-VALUE");
            config.Set(key, expected);

            var actual = config.Get(key);
            Assert.Equal(expected, actual);
        }

        //TODO: Refactor unit tests
    }
}
