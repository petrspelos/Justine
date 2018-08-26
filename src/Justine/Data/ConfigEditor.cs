using System.Configuration;

namespace Justine.Data
{
    public class ConfigEditor
    {
        private Configuration file;

        public ConfigEditor()
        {
            file = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public void CreateSetting(ConfigSetting setting)
        {
            file.AppSettings.Settings.Add(setting.Key, setting.Value);
        }

        public void UpdateSetting(ConfigSetting setting)
        {
            file.AppSettings.Settings[setting.Key].Value = setting.Value;
        }

        public void Save()
        {
            file.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(file.AppSettings.SectionInformation.Name);
        }
    }
}
