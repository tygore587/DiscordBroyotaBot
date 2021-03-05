using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.Memes.Models;

namespace DiscordBot.Data.Memes.DataSources
{
    public interface IMemesRemoteDataSource
    {
        Task<MemeRemote> GetRandomMeme(CancellationToken cancellationToken = default);
    }
}