using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.Memes.Models;
using Refit;

namespace DiscordBot.Data.Memes.DataSources
{
    internal interface IMemeApi
    {
        const string BaseUrl = "https://meme-api.herokuapp.com";

        [Get("/gimme")]
        Task<MemeRemote> GetRandomMeme(CancellationToken cancellationToken);
    }
}