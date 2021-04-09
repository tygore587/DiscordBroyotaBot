using System.Threading.Tasks;
using DiscordBot.Data.WatchTogether.Models;

namespace DiscordBot.Data.WatchTogether.DataSources
{
    public interface IWatchTogetherRemoteDataSource
    {
        Task<WatchTogetherRoomRemote> CreateWatchTogetherRoom(string? youtubeLink = null);
    }
}