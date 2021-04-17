using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Data.News.DataSources.Remote.Tagesschau
{
    internal interface ITagesschauRemoteDataSource
    {
        Task<List<NewsInternal>> GetTagesschauNews(CancellationToken cancellationToken = default);
    }
}