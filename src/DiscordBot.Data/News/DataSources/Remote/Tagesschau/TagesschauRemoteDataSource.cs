using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Data.News.DataSources.Remote.Tagesschau
{
    internal class TagesschauRemoteDataSource : ITagesschauRemoteDataSource
    {
        private readonly ITagesschauApi _tagesschauApi;

        public TagesschauRemoteDataSource(ITagesschauApi tagesschauApi)
        {
            _tagesschauApi = tagesschauApi;
        }

        public async Task<List<NewsEntity>> GetTagesschauNews(CancellationToken cancellationToken = default)
        {
            var result = await _tagesschauApi.GetTagesschauNews(cancellationToken);
            return result.ToNewsInternalList().ToList();
        }
    }
}