namespace Justine.Settings
{
    public interface JustineSettings
    {
        string Get(string key);
        void Set(string key, string value);
    }
}
