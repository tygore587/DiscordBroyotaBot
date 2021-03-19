using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Data.News.DataSources;
using DiscordBot.Data.News.Extensions;
using DiscordBot.Domain.News.Entities;
using DiscordBot.Domain.News.Repositories;

namespace DiscordBot.Data.News.Repositories
{
    internal class NewsRepository : INewsRepository
    {
        private readonly INewsLocalCacheDataSource _newsLocalCacheDataSource;
        private readonly ITagesschauRemoteDataSource _tagesschauRemoteDataSource;

        public NewsRepository(ITagesschauRemoteDataSource tagesschauRemoteDataSource,
            INewsLocalCacheDataSource newsLocalCacheDataSource)
        {
            _tagesschauRemoteDataSource = tagesschauRemoteDataSource;
            _newsLocalCacheDataSource = newsLocalCacheDataSource;
        }

        public async Task<IEnumerable<NewsInternal>?> GetTagesschauNews()
        {
            var cachedNews = await _newsLocalCacheDataSource.Get(NewsCacheKeys.Tagesschau);

            if (cachedNews?.Any() == true)
                return cachedNews;

            var rssRemote = await _tagesschauRemoteDataSource.GetTagesschauNews();

            if (rssRemote == null)
                return null;

            var newsResult = rssRemote.ToNewsInternalList()!.ToList();

            await _newsLocalCacheDataSource.Set(NewsCacheKeys.Tagesschau, newsResult);

            return rssRemote.ToNewsInternalList();
        }
    }
}