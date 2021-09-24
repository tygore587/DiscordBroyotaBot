using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether.DataSources
{
    public interface IWatchTogetherRemoteDataSource
    {
        Task AddVideosToRoom(string roomId, IEnumerable<string> youtubeLinks);

        Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null);
    }
}