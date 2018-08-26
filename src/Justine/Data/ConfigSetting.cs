namespace Justine.Data
{
    public class ConfigSetting
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public ConfigSetting(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
