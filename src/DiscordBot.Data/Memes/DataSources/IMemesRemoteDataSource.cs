using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data;
using DiscordBot.Domain.Memes.Entities;

[assembly: InternalsVisibleTo(TestConstants.MockAssemblyName)]

namespace DiscordBot.Data.Memes.DataSources
{
    internal interface IMemesRemoteDataSource
    {
        Task<Meme> GetRandomMeme(CancellationToken cancellationToken = default);
    }
}