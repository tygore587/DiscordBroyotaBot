using DiscordBot.Data.Youtube.DataSources.Local;
using DiscordBot.Data.Youtube.DataSources.Remote;
using DiscordBot.Domain.Youtube.Entities;
using DiscordBot.Domain.Youtube.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Youtube
{
    public class YoutubeRepository : IYoutubeRepository
    {
        private readonly IYoutubeRemoteDataSource _youtubeRemoteDataSource;

        private readonly IYoutubeLocalCacheDataSource _youtubeLocalCacheDataSource;

        public YoutubeRepository(IYoutubeRemoteDataSource youtubeRemoteDataSource, IYoutubeLocalCacheDataSource localCacheDataSource)
        {
            _youtubeRemoteDataSource = youtubeRemoteDataSource;
            _youtubeLocalCacheDataSource = localCacheDataSource;
        }

        public async Task<List<YoutubeVideo>> GetVideosFromChannel(string channelId)
        {
            if (string.IsNullOrWhiteSpace(channelId))
                throw new ArgumentNullException(nameof(channelId));


            var cachedVideos = await _youtubeLocalCacheDataSource.GetYoutubeVideos(channelId);

            if (cachedVideos != null)
                return cachedVideos;

            var youtubeVideos = await _youtubeRemoteDataSource.GetUploadedVideos(channelId);

            await _youtubeLocalCacheDataSource.SaveYoutubeVideos(channelId, youtubeVideos);

            return youtubeVideos;
        }
    }
}
