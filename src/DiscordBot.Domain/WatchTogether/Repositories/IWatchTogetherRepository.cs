using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Domain.WatchTogether.Repositories
{
    public interface IWatchTogetherRepository
    {
        Task AddVideosToRoom(string roomId, IEnumerable<string> videoLinks);
        Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null);
    }
}