using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Domain.Memes.Entities;

namespace DiscordBot.Data.Memes.DataSources
{
    internal interface IMemesRemoteDataSource
    {
        Task<Meme> GetRandomMeme(CancellationToken cancellationToken = default);
    }
}