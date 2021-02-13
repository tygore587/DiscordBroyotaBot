using DiscordBot.Core.Data.Requests;
using DiscordBot.Memes.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot.Memes.Data.DataSources
{
    public class MemesRemoteDataSource : IMemesRemoteDataSource
    {
        private const string BaseUrl = "https://meme-api.herokuapp.com";

        public IRequestClient RequestClient;

        public MemesRemoteDataSource(IRequestClient requestClient)
        {
            RequestClient = requestClient;
        }

        public Task<MemeRemote> GetRandomMeme(CancellationToken cancellationToken = default) =>
                 RequestClient.GetJsonAsync<MemeRemote>(BaseUrl, new() { "gimme" }, cancellationToken);
    }
}