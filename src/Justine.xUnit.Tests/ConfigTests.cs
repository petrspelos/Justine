using Xunit;
using Justine.Data;

namespace Justine.Tests
{
    public class ConfigTests
    {
        [Fact]
        public void GetValueFromConfigTest()
        {
            const string key = "non-existant-key";
            
            IJustineConfig config = new JustineConfig();
            
            var actual = config.Get(key);

            Assert.Equal(null, actual);
        }

        //TODO: More Unit Tests
    }
}
