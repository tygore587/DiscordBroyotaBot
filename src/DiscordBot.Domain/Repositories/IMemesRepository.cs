using System.Threading.Tasks;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Domain.Repositories
{
    public interface IMemesRepository
    {
        Task<Meme?> GetRandomMeme();
    }
}