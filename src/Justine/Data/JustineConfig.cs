using System.Configuration;

namespace Justine.Data
{
    public class JustineConfig : IJustineConfig
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public void Set(string key, string value)
        {
            AddOrUpdateSetting(new ConfigSetting(key, value));
        }

        private void AddOrUpdateSetting(ConfigSetting setting)
        {
            var editor = new ConfigEditor();
            if(KeyExists(setting.Key))
            {
                editor.UpdateSetting(setting);
            }
            else
            {
                editor.CreateSetting(setting);
            }
            editor.Save();
        }

        private bool KeyExists(string key)
        {
            return !(ConfigurationManager.AppSettings[key] is null);
        }
    }
}
