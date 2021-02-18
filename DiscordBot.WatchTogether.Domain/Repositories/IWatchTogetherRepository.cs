using DiscordBot.WatchTogether.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.WatchTogether.Domain.Repositories
{
    public interface IWatchTogetherRepository
    {
        Task<CreatedRoom> CreateWatchTogetherRoom(string youtubeLink);
    }
}
