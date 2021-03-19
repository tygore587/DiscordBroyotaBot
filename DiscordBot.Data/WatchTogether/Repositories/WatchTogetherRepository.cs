using System.Threading.Tasks;
using DiscordBot.Data.WatchTogether.DataSources;
using DiscordBot.Data.WatchTogether.Extensions;
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

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink)
        {
            var createdRoomRemote = await _watchTogetherRemoteDataSource.CreateWatchTogetherRoom(youtubeLink);

            return createdRoomRemote.ToCreatedRoom();
        }
    }
}