using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Core.Constants;
using DiscordBot.Data.WatchTogether.Models;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether.DataSources
{
    internal class WatchTogetherRemoteDataSource : IWatchTogetherRemoteDataSource
    {

        private readonly IWatchTogetherApi _watchTogetherApi;


        public WatchTogetherRemoteDataSource(IWatchTogetherApi watchTogetherApi)
        {
            _watchTogetherApi = watchTogetherApi;
        }

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null)
        {
            if (string.IsNullOrWhiteSpace(EnvironmentVariables.WatchTogetherApiKey))
                throw new ArgumentNullException(nameof(EnvironmentVariables.WatchTogetherApiKey),
                    "Watch together api key was null or empty.");

            var createRoomBody = new WatchTogetherRoomCreationRequestRemote(EnvironmentVariables.WatchTogetherApiKey)
            {
                BackgroundColor = "#131313",
                Share = youtubeLink,
                BackgroundOpacity = null
            };

            var result = await _watchTogetherApi.CreateRoom(createRoomBody);

            return result.ToCreatedRoom();
        }

        public async Task AddVideosToRoom(string roomId, IEnumerable<Video> youtubeLinks)
        {
            if (string.IsNullOrWhiteSpace(EnvironmentVariables.WatchTogetherApiKey))
                throw new ArgumentNullException(nameof(EnvironmentVariables.WatchTogetherApiKey),
                    "Watch together api key was null or empty.");

            if (string.IsNullOrWhiteSpace(roomId))
                throw new ArgumentNullException(nameof(roomId), "Room ID must not be null or empty.");

            var videosToAdd = youtubeLinks.ToWatchTogetherRoomAddVideosUrlsList();

            var videosToAddRemote = new WatchTogetherRoomAddVideosRemote(EnvironmentVariables.WatchTogetherApiKey, videosToAdd);

            await _watchTogetherApi.AddVideoToRoomPlayList(roomId, videosToAddRemote);
        }
    }
}