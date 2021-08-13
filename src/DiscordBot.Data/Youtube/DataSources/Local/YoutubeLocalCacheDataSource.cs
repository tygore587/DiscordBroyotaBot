using DiscordBot.Core.Data.Cache;
using DiscordBot.Domain.Youtube.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Youtube.DataSources.Local
{
    public class YoutubeLocalCacheDataSource : IYoutubeLocalCacheDataSource
    {
        private const string _keyPrefix = "YoutubeVideos_";

        private IExpirableMemCache<List<YoutubeVideo>> _expirableMemCache;

        public YoutubeLocalCacheDataSource(ILogger logger, IExpirableMemCache<List<YoutubeVideo>>? expirableMemCache = null)
        {
            _expirableMemCache = expirableMemCache ?? new ExpirableMemCache<List<YoutubeVideo>>(CacheTimings.Long, logger);
        }

        public Task<List<YoutubeVideo>?> GetYoutubeVideos(string channelId)
        {
            return _expirableMemCache.GetValue(CreateCacheKey(channelId));
        }

        public Task SaveYoutubeVideos(string channelId, List<YoutubeVideo> youtubeVideos)
        {
            return _expirableMemCache.Set(CreateCacheKey(channelId), youtubeVideos);
        }

        private CacheKey CreateCacheKey(string channelId)
        {
            return new CacheKey(_keyPrefix, new[] { channelId });
        } 
    }
}
