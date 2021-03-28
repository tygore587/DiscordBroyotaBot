using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace DiscordBot.Core.Cache
{
    public abstract class ExpirableMemCache<TItem>
    {
        private readonly MemoryCacheEntryOptions _entryOptions;
        private readonly ILogger _logger;
        private readonly MemoryCache _memoryCache;

        protected ExpirableMemCache(TimeSpan expireTimeSpan, ILogger logger) : this(
            new MemoryCache(new MemoryCacheOptions()),
            new MemoryCacheEntryOptions().SetAbsoluteExpiration(expireTimeSpan), logger)
        {
        }

        private ExpirableMemCache(MemoryCache memoryCache, MemoryCacheEntryOptions options, ILogger logger)
        {
            _memoryCache = memoryCache;
            _entryOptions = options;
            _logger = logger;
        }

        protected abstract string KeyPrefix { get; }

        protected Task Set(CacheKey key, TItem? item)
        {
            if (Equals(item, default(TItem?)))
                return Task.CompletedTask;

            try
            {
                return Task.Run(() => _memoryCache.Set(key.ToCacheKey(), item, _entryOptions));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Can't set value in cache for {key}.", key);
                return Task.CompletedTask;
            }
        }

        protected bool TryGetValue(CacheKey key, out TItem? item)
        {
            try
            {
                return _memoryCache.TryGetValue(key.ToCacheKey(), out item);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Can't get value in cache for {key}.", key);
                item = default;
                return false;
            }
        }

        protected Task<TItem?> GetValue(CacheKey key)
        {
            try
            {
                return Task.Run(() => _memoryCache.Get<TItem?>(key.ToCacheKey()));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Can't get value in cache for {key}.", key);
                return Task.FromResult<TItem?>(default);
            }
        }

        protected Task RemoveValue(CacheKey key)
        {
            try
            {
                return Task.Run(() => _memoryCache.Remove(key.ToCacheKey()));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Can't remove value from cache for {key}.", key);
                return Task.CompletedTask;
            }
        }

        protected CacheKey CreateCacheKey(params string[] parameters)
        {
            return new(KeyPrefix, parameters);
        }
    }
}