using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Core.Cache;

namespace DiscordBot.Core.Data.Cache
{
    public interface IExpirableMemCache<TItem>
    {
        Task Set(CacheKey key, TItem item);
        bool TryGetValue(CacheKey key, out TItem? item);
        Task<TItem?> GetValue(CacheKey key);
        Task RemoveValue(CacheKey key);
        CacheKey CreateCacheKey(string keyPrefix, IEnumerable<string> parameters);
    }
}