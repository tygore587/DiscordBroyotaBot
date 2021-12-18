using DiscordBot.Domain.Youtube.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Domain.Youtube.Repositories
{
    public interface IYoutubeRepository
    {
        Task<List<YoutubeVideo>> GetVideosFromChannel(string channelId);
    }
}
