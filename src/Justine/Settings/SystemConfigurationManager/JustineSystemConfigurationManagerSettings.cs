using System.Configuration;

namespace Justine.Settings.SystemConfigurationManager
{
    public class JustineSystemConfigurationManagerSettings : JustineSettings
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public void Set(string key, string value)
        {
            StoreSetting(new SettingKeyValuePair(key, value));
        }

        private static void StoreSetting(SettingKeyValuePair setting)
        {
            var editor = new ConfigurationFileEditor();
            editor.WriteSetting(setting);
            editor.Save();
        }
    }
}
