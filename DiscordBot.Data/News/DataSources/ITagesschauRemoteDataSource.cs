using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.News.Models;

namespace DiscordBot.Data.News.DataSources
{
    internal interface ITagesschauRemoteDataSource
    {
        Task<RssRemote> GetTagesschauNews(CancellationToken cancellationToken = default);
    }
}