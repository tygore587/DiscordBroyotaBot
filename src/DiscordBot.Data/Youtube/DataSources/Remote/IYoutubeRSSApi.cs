using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Data.Youtube.Models;
using Refit;

namespace DiscordBot.Data.Youtube.DataSources.Remote
{
    public interface IYoutubeRSSApi
    {
        const string BaseUrl = "https://www.youtube.com/feeds/videos.xml";

        [Get("/")]
        public Task<YoutubeFeedRootRemote> GetChannelVideos([Query] string channelId);
    }
}
