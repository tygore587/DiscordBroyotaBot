using System.Threading.Tasks;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Domain.WatchTogether.Repositories
{
    public interface IWatchTogetherRepository
    {
        Task<CreatedRoom> CreateWatchTogetherRoom(string youtubeLink);
    }
}