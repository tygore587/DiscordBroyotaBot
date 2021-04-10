using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Core.Cache;
using DiscordBot.Domain.Entities;
using Serilog;

namespace DiscordBot.Data.DataSources.Local.News
{
    public class NewsLocalCacheDataSource : ExpirableMemCache<List<NewsInternal>>, INewsLocalCacheDataSource
    {
        public NewsLocalCacheDataSource(ILogger logger) : base(TimeSpan.FromMinutes(10), logger)
        {
        }

        protected override string KeyPrefix => "news_";

        public Task Set(string newsPortal, List<NewsInternal> newsInternal)
        {
            return Set(CreateCacheKey(newsPortal), newsInternal);
        }

        public bool TryGet(string newsPortal, out List<NewsInternal>? newsInternal)
        {
            return TryGetValue(CreateCacheKey(newsPortal), out newsInternal);
        }

        public Task<List<NewsInternal>?> Get(string newsPortal)
        {
            return GetValue(CreateCacheKey(newsPortal));
        }

        public Task Remove(string newsPortal)
        {
            return RemoveValue(CreateCacheKey(newsPortal));
        }
    }
}