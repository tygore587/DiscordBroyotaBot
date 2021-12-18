using System.Collections.Generic;
using System.Linq;

namespace DiscordBot.Core.Data.Cache
{
    public class CacheKey
    {
        public CacheKey(string keyPrefix, IEnumerable<string> keyParameters)
        {
            KeyPrefix = keyPrefix;
            KeyParameters = keyParameters.ToList();
        }

        private string KeyPrefix { get; }

        private List<string> KeyParameters { get; }

        public string ToCacheKey()
        {
            return $"{KeyPrefix}{string.Join("_", KeyParameters)}";
        }
    }
}