using DiscordBot.Domain.Youtube.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Youtube.DataSources.Remote
{
    public class YoutubeRemoteDataSource : IYoutubeRemoteDataSource
    {
        private readonly IYoutubeRSSApi _youtubeRSSApi;

        public YoutubeRemoteDataSource(IYoutubeRSSApi youtubeRSSApi)
        {
            _youtubeRSSApi = youtubeRSSApi;
        }

        public async Task<List<YoutubeVideo>> GetUploadedVideos(string channelId)
        {
            if (string.IsNullOrWhiteSpace(channelId))
                throw new ArgumentNullException(nameof(channelId), "Channel ID must not be null or empty.");

            var channelInfo = await _youtubeRSSApi.GetChannelVideos(channelId);

            return channelInfo.YoutubeVideos.WithoutEmptyLinkVideos().ToYoutubeVideos();
        }
    }
}
