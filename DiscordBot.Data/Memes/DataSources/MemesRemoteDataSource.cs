using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.Memes.Models;
using DiscordBot.Data.Requests;

namespace DiscordBot.Data.Memes.DataSources
{
    public class MemesRemoteDataSource : IMemesRemoteDataSource
    {
        private const string BaseUrl = "https://meme-api.herokuapp.com";

        private readonly IRequestClient _requestClient;

        public MemesRemoteDataSource(IRequestClient requestClient)
        {
            _requestClient = requestClient;
        }

        public Task<MemeRemote> GetRandomMeme(CancellationToken cancellationToken = default)
        {
            return _requestClient.GetJsonAsync<MemeRemote>(BaseUrl, new List<string> {"gimme"},
                cancellationToken: cancellationToken);
        }
    }
}