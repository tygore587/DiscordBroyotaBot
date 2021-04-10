using System.Threading.Tasks;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Domain.Repositories
{
    public interface IWatchTogetherRepository
    {
        Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null);
    }
}