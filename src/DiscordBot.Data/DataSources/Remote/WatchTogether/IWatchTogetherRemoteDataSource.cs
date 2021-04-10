using System.Threading.Tasks;
using DiscordBot.Data.Models.Remote.WatchTogether;

namespace DiscordBot.Data.DataSources.Remote.WatchTogether
{
    public interface IWatchTogetherRemoteDataSource
    {
        Task<WatchTogetherRoomRemote> CreateWatchTogetherRoom(string? youtubeLink = null);
    }
}