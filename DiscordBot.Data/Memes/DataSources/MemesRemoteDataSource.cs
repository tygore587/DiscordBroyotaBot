using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.Memes.Extensions;
using DiscordBot.Data.Memes.Models;
using DiscordBot.Data.Requests;
using DiscordBot.Domain.Memes.Entities;

[assembly: InternalsVisibleTo("DiscordBot.Data.Tests.Unit")]

namespace DiscordBot.Data.Memes.DataSources
{
    internal class MemesRemoteDataSource : IMemesRemoteDataSource
    {
        private const string BaseUrl = "https://meme-api.herokuapp.com";

        private readonly IRequestClient _requestClient;

        public MemesRemoteDataSource(IRequestClient requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<Meme> GetRandomMeme(CancellationToken cancellationToken = default)
        {
            var response =
                await _requestClient.GetAsync<MemeRemote>(BaseUrl, new List<string> {"gimme"}, cancellationToken);

            return response.ToMeme();
        }
    }
}