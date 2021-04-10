using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data;
using DiscordBot.Domain.Entities;

[assembly: InternalsVisibleTo(TestConstants.MockAssemblyName)]

namespace DiscordBot.Data.DataSources.Remote.Memes
{
    internal interface IMemesRemoteDataSource
    {
        Task<Meme> GetRandomMeme(CancellationToken cancellationToken = default);
    }
}