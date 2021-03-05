using System.Threading.Tasks;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.WatchTogether.Domain.Repositories
{
    public interface IWatchTogetherRepository
    {
        Task<CreatedRoom> CreateWatchTogetherRoom(string youtubeLink);
    }
}