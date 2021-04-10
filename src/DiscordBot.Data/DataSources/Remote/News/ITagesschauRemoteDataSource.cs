using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Data.DataSources.Remote.News
{
    internal interface ITagesschauRemoteDataSource
    {
        Task<List<NewsInternal>> GetTagesschauNews(CancellationToken cancellationToken = default);
    }
}