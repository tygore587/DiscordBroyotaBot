using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.Models.Remote;
using Refit;

namespace DiscordBot.Data.DataSources.Remote.Memes
{
    public interface IMemeApi
    {
        const string BaseUrl = "https://meme-api.herokuapp.com";

        [Get("/gimme")]
        Task<MemeRemote> GetRandomMeme(CancellationToken cancellationToken);
    }
}