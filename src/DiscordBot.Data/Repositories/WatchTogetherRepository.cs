using System.Threading.Tasks;
using DiscordBot.Data.DataSources.Remote.WatchTogether;
using DiscordBot.Data.Extensions;
using DiscordBot.Domain.Entities;
using DiscordBot.Domain.Repositories;

namespace DiscordBot.Data.Repositories
{
    internal class WatchTogetherRepository : IWatchTogetherRepository
    {
        private readonly IWatchTogetherRemoteDataSource _watchTogetherRemoteDataSource;

        public WatchTogetherRepository(IWatchTogetherRemoteDataSource watchTogetherRemoteDataSource)
        {
            _watchTogetherRemoteDataSource = watchTogetherRemoteDataSource;
        }

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null)
        {
            var createdRoomRemote = await _watchTogetherRemoteDataSource.CreateWatchTogetherRoom(youtubeLink);

            return createdRoomRemote.ToCreatedRoom();
        }
    }
}