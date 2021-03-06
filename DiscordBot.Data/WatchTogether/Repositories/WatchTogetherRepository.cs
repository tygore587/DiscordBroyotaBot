using System.Threading.Tasks;
using DiscordBot.Data.WatchTogether.DataSources;
using DiscordBot.Domain.WatchTogether.Entities;
using DiscordBot.Domain.WatchTogether.Repositories;

namespace DiscordBot.Data.WatchTogether.Repositories
{
    internal class WatchTogetherRepository : IWatchTogetherRepository
    {
        private readonly IWatchTogetherRemoteDataSource _watchTogetherRemoteDataSource;

        public WatchTogetherRepository(IWatchTogetherRemoteDataSource watchTogetherRemoteDataSource)
        {
            _watchTogetherRemoteDataSource = watchTogetherRemoteDataSource;
        }

        public Task<CreatedRoom> CreateWatchTogetherRoom(string youtubeLink)
        {
            return _watchTogetherRemoteDataSource.CreateWatchTogetherRoom(youtubeLink);
        }
    }
}