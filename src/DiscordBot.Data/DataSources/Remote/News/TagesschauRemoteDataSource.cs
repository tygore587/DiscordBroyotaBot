using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.Extensions;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Data.DataSources.Remote.News
{
    internal class TagesschauRemoteDataSource : ITagesschauRemoteDataSource
    {
        private readonly ITagesschauApi _tagesschauApi;

        public TagesschauRemoteDataSource(ITagesschauApi tagesschauApi)
        {
            _tagesschauApi = tagesschauApi;
        }

        public async Task<List<NewsInternal>> GetTagesschauNews(CancellationToken cancellationToken = default)
        {
            var result = await _tagesschauApi.GetTagesschauNews(cancellationToken);
            return result.ToNewsInternalList().ToList();
        }
    }
}