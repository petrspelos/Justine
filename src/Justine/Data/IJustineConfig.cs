namespace Justine.Data
{
    public interface IJustineConfig
    {
        string Get(string key);
        void Set(string key, string value);
    }
}
