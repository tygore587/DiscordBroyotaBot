using Discordbot.Memes.Domain.Entities;
using System.Threading.Tasks;

namespace Discordbot.Memes.Domain.Repositories
{
    public interface IMemesRepository
    {
        Task<Meme> GetRandomMeme();
    }
}