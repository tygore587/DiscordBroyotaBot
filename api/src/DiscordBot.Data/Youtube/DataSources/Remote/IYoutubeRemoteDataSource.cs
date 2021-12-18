using DiscordBot.Domain.Youtube.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Youtube.DataSources.Remote
{
    public interface IYoutubeRemoteDataSource
    {
        Task<List<YoutubeVideo>> GetUploadedVideos(string channelId);
    }
}
