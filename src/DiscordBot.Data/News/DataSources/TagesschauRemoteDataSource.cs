using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.News.Models;

namespace DiscordBot.Data.News.DataSources
{
    internal class TagesschauRemoteDataSource : ITagesschauRemoteDataSource
    {
        private readonly ITagesschauApi _tagesschauApi;

        public TagesschauRemoteDataSource(ITagesschauApi tagesschauApi)
        {
            _tagesschauApi = tagesschauApi;
        }

        public Task<RssRemote> GetTagesschauNews(CancellationToken cancellationToken = default)
        {
            return _tagesschauApi.GetTagesschauNews(cancellationToken);
        }
    }
}