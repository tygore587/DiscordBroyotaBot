﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace DiscordBot.Core.Cache
{
    public abstract class ExpirableMemCache<TItem>
    {
        private readonly MemoryCacheEntryOptions _entryOptions;
        private readonly MemoryCache _memoryCache;

        protected ExpirableMemCache(TimeSpan expireTimeSpan) : this(
            new MemoryCache(new MemoryCacheOptions()),
            new MemoryCacheEntryOptions().SetAbsoluteExpiration(expireTimeSpan))
        {
        }

        private ExpirableMemCache(MemoryCache memoryCache, MemoryCacheEntryOptions options)
        {
            _memoryCache = memoryCache;
            _entryOptions = options;
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
                Console.WriteLine(ex.Message);
                return Task.CompletedTask;
            }
        }

        protected bool TryGetValue(CacheKey key, out TItem? item)
        {
            try
            {
                return _memoryCache.TryGetValue(key.ToCacheKey(), out item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.FromResult<TItem?>(default);
            }
        }

        protected Task RemoveValue(CacheKey key)
        {
            try
            {
                return Task.Run(() => _memoryCache.Remove(key.ToCacheKey()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.CompletedTask;
            }
        }

        protected CacheKey CreateCacheKey(params string[] parameters)
        {
            return new(KeyPrefix, parameters);
        }
    }
}