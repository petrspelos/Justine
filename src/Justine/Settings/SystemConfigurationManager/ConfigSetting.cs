namespace Justine.Settings.SystemConfigurationManager
{
    public class SettingKeyValuePair
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public SettingKeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
