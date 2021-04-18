using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Core.Data.Cache;
using DiscordBot.Domain.News.Entities;
using Serilog;

namespace DiscordBot.Data.News.DataSources.Local
{
    public class NewsLocalCacheDataSource : INewsLocalCacheDataSource
    {
        private const string KeyPrefix = "news_";
        private readonly IExpirableMemCache<List<NewsEntity>> _memCache;

        public NewsLocalCacheDataSource(ILogger logger, IExpirableMemCache<List<NewsEntity>>? memCache = null)
        {
            _memCache = memCache ??
                        new ExpirableMemCache<List<NewsEntity>>(TimeSpan.FromMinutes(10), logger);
        }

        public Task Set(string newsPortal, List<NewsEntity> newsInternal)
        {
            return _memCache.Set(CreateCacheKey(newsPortal), newsInternal);
        }

        public bool TryGet(string newsPortal, out List<NewsEntity>? newsInternal)
        {
            return _memCache.TryGetValue(CreateCacheKey(newsPortal), out newsInternal);
        }

        public Task<List<NewsEntity>?> Get(string newsPortal)
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