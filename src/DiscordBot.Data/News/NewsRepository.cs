using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Data.News.DataSources.Local;
using DiscordBot.Data.News.DataSources.Remote.Tagesschau;
using DiscordBot.Domain.News.Entities;
using DiscordBot.Domain.News.Repositories;

namespace DiscordBot.Data.News
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

            var news = await _tagesschauRemoteDataSource.GetTagesschauNews();

            if (news.Any() != true)
                return null;

            await _newsLocalCacheDataSource.Set(NewsCacheKeys.Tagesschau, news);

            return news;
        }
    }
}