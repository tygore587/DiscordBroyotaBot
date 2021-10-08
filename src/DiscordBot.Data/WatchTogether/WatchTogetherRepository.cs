using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Core.Linq;
using DiscordBot.Data.WatchTogether.DataSources;
using DiscordBot.Domain.WatchTogether.Entities;
using DiscordBot.Domain.WatchTogether.Repositories;

namespace DiscordBot.Data.WatchTogether
{
    internal class WatchTogetherRepository : IWatchTogetherRepository
    {
        private readonly IWatchTogetherRemoteDataSource _watchTogetherRemoteDataSource;

        public WatchTogetherRepository(IWatchTogetherRemoteDataSource watchTogetherRemoteDataSource)
        {
            _watchTogetherRemoteDataSource = watchTogetherRemoteDataSource;
        }

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string? videoLink = null)
        {
            return await _watchTogetherRemoteDataSource.CreateWatchTogetherRoom(videoLink);
        }

        public async Task AddVideosToRoom(string roomId, IEnumerable<Video> videoLinks)
        {
            var splittedVideoLinks = videoLinks.SplitIntoChunks(50);

            foreach (var linkChunk in splittedVideoLinks)
            {
                await _watchTogetherRemoteDataSource.AddVideosToRoom(roomId, linkChunk);
            }
        }
    }
}