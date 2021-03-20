﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Core.Cache;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Data.News.DataSources
{
    public class NewsLocalCacheDataSource : ExpirableMemCache<List<NewsInternal>>, INewsLocalCacheDataSource
    {
        public NewsLocalCacheDataSource() : base(TimeSpan.FromMinutes(10))
        {
        }

        protected override string KeyPrefix { get; } = "news_";

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