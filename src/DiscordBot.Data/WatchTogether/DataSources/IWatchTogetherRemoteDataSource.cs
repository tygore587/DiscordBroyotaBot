using System.Threading.Tasks;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether.DataSources
{
    public interface IWatchTogetherRemoteDataSource
    {
        Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null);
    }
}