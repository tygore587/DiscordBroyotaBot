using Discordbot.WatchTogether.Data.DataSources;
using DiscordBot.WatchTogether.Domain.Entities;
using DiscordBot.WatchTogether.Domain.Repositories;
using System.Threading.Tasks;

namespace Discordbot.WatchTogether.Data.Repositories
{
    public class WatchTogetherRepository : IWatchTogetherRepository
    {
        private readonly IWatchTogetherRemoteDataSource WatchTogetherRemoteDataSource;

        public WatchTogetherRepository(IWatchTogetherRemoteDataSource watchTogetherRemoteDataSource)
        {
            WatchTogetherRemoteDataSource = watchTogetherRemoteDataSource;
        }

        public Task<CreatedRoom> CreateWatchTogetherRoom(string youtubeLink)
            => WatchTogetherRemoteDataSource.CreateWatchTogetherRoom(youtubeLink);
    }
}