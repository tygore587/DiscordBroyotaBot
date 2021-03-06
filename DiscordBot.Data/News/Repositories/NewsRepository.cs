using System.Threading.Tasks;
using DiscordBot.Data.News.DataSources;
using DiscordBot.Domain.News.Repositories;

namespace DiscordBot.Data.News.Repositories
{
    internal class NewsRepository : INewsRepository
    {
        private readonly ITagesschauRemoteDataSource _tagesschauRemoteDataSource;

        public NewsRepository(ITagesschauRemoteDataSource tagesschauRemoteDataSource)
        {
            _tagesschauRemoteDataSource = tagesschauRemoteDataSource;
        }

        public Task<string> GetLatestTagesschauNews()
        {
            return _tagesschauRemoteDataSource.GetTagesschauNews();
        }
    }
}