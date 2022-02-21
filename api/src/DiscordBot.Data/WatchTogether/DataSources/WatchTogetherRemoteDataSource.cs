using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Core.Constants;
using DiscordBot.Core.Secrets;
using DiscordBot.Data.WatchTogether.Models;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether.DataSources
{
    internal class WatchTogetherRemoteDataSource : IWatchTogetherRemoteDataSource
    {

        private readonly IWatchTogetherApi _watchTogetherApi;
        private readonly ApplicationSecrets applicationSecrets;


        public WatchTogetherRemoteDataSource(
            IWatchTogetherApi watchTogetherApi,
            ApplicationSecrets applicationSecrets)
        {
            _watchTogetherApi = watchTogetherApi;
            this.applicationSecrets = applicationSecrets;
        }

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null)
        {
            if (string.IsNullOrWhiteSpace(applicationSecrets.WatchTogetherApiKey))
                throw new ArgumentNullException(nameof(applicationSecrets.WatchTogetherApiKey),
                    "Watch together api key was null or empty.");

            var createRoomBody = new WatchTogetherRoomCreationRequestRemote(applicationSecrets.WatchTogetherApiKey)
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
            if (string.IsNullOrWhiteSpace(applicationSecrets.WatchTogetherApiKey))
                throw new ArgumentNullException(nameof(applicationSecrets.WatchTogetherApiKey),
                    "Watch together api key was null or empty.");

            if (string.IsNullOrWhiteSpace(roomId))
                throw new ArgumentNullException(nameof(roomId), "Room ID must not be null or empty.");

            var videosToAdd = youtubeLinks.ToWatchTogetherRoomAddVideosUrlsList();

            var videosToAddRemote = new WatchTogetherRoomAddVideosRemote(applicationSecrets.WatchTogetherApiKey, videosToAdd);

            await _watchTogetherApi.AddVideoToRoomPlayList(roomId, videosToAddRemote);
        }
    }
}