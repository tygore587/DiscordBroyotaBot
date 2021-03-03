using DiscordBot.WatchTogether.Domain.Entities;
using System.Threading.Tasks;

namespace Discordbot.WatchTogether.Data.DataSources
{
    public interface IWatchTogetherRemoteDataSource
    {
        Task<CreatedRoom> CreateWatchTogetherRoom(string youtubeLink = null);
    }
}
