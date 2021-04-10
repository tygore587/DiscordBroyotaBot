using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data;
using DiscordBot.Data.Extensions;
using DiscordBot.Domain.Entities;

[assembly: InternalsVisibleTo(TestConstants.AssemblyName)]

namespace DiscordBot.Data.DataSources.Remote.Memes
{
    public class MemesRemoteDataSource : IMemesRemoteDataSource
    {
        private readonly IMemeApi _memeApi;

        public MemesRemoteDataSource(IMemeApi memeApi)
        {
            _memeApi = memeApi;
        }

        public async Task<Meme> GetRandomMeme(CancellationToken cancellationToken = default)
        {
            var response =
                await _memeApi.GetRandomMeme(cancellationToken);

            return response.ToMeme();
        }
    }
}