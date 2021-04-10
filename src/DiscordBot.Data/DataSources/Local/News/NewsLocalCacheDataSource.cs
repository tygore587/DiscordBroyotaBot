using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Core.Cache;
using DiscordBot.Domain.Entities;
using Serilog;

namespace DiscordBot.Data.DataSources.Local.News
{
    public class NewsLocalCacheDataSource : INewsLocalCacheDataSource
    {
        private const string KeyPrefix = "news_";
        private readonly IExpirableMemCache<List<NewsInternal>> _memCache;

        public NewsLocalCacheDataSource(ILogger logger, IExpirableMemCache<List<NewsInternal>>? memCache = null)
        {
            _memCache = memCache ??
                        new ExpirableMemCache<List<NewsInternal>>(TimeSpan.FromMinutes(10), logger);
        }

        public Task Set(string newsPortal, List<NewsInternal> newsInternal)
        {
            return _memCache.Set(CreateCacheKey(newsPortal), newsInternal);
        }

        public bool TryGet(string newsPortal, out List<NewsInternal>? newsInternal)
        {
            return _memCache.TryGetValue(CreateCacheKey(newsPortal), out newsInternal);
        }

        public Task<List<NewsInternal>?> Get(string newsPortal)
        {
            return _memCache.GetValue(CreateCacheKey(newsPortal));
        }

        public Task Remove(string newsPortal)
        {
            return _memCache.RemoveValue(CreateCacheKey(newsPortal));
        }

        private CacheKey CreateCacheKey(string newsPortal)
        {
            return _memCache.CreateCacheKey(KeyPrefix, new[] {newsPortal});
        }
    }
}