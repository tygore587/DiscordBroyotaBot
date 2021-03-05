using System.Threading.Tasks;
using DiscordBot.Domain.Memes.Entities;

namespace DiscordBot.Domain.Memes.Repositories
{
    public interface IMemesRepository
    {
        Task<Meme> GetRandomMeme();
    }
}