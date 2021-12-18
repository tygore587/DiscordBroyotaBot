using DiscordBot.Domain.Youtube.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Youtube.DataSources.Local
{
    public interface IYoutubeLocalCacheDataSource
    {
        Task<List<YoutubeVideo>?> GetYoutubeVideos(string channelId);
        Task SaveYoutubeVideos(string channelId, List<YoutubeVideo> youtubeVideos);
    }
}
