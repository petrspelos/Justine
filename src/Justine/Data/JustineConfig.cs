using System.Configuration;

namespace Justine.Data
{
    public class JustineConfig : IJustineConfig
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
