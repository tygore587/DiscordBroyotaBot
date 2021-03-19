namespace DiscordBot.Core.Cache
{
    public class CacheKey
    {
        public CacheKey(string keyPrefix, string[] keyParameters)
        {
            KeyPrefix = keyPrefix;
            KeyParameters = keyParameters;
        }

        private string KeyPrefix { get; }

        private string[] KeyParameters { get; }

        public string ToCacheKey()
        {
            return $"{KeyPrefix}{string.Join("_", KeyParameters)}";
        }
    }
}