using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Core.Constants;
using DiscordBot.Data.Requests;
using DiscordBot.Data.WatchTogether.Extensions;
using DiscordBot.Data.WatchTogether.Models;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether.DataSources
{
    public class WatchTogetherRemoteDataSource : IWatchTogetherRemoteDataSource
    {
        private const string BaseUrl = "https://w2g.tv/";

        private readonly IRequestClient _requestClient;

        public WatchTogetherRemoteDataSource(IRequestClient requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null)
        {
            if (string.IsNullOrWhiteSpace(EnvironmentVariables.WatchTogetherApiKey))
                throw new ArgumentNullException(nameof(EnvironmentVariables.WatchTogetherApiKey),
                    "Watch together api key was null or empty.");

            var createRoomBody = new RoomCreationRemote(EnvironmentVariables.WatchTogetherApiKey)
            {
                BackgroundColor = "#131313",
                Share = youtubeLink
            };

            var createdRoom = await _requestClient.PostJsonAsync<RoomCreationRemote, CreatedRoomRemote>(createRoomBody,
                BaseUrl, new List<string> {"rooms", "create.json"});

            //TODO: Add own exception
            if (string.IsNullOrWhiteSpace(createdRoom?.StreamKey))
                throw new ArgumentNullException(nameof(createdRoom.StreamKey),
                    "No room key was returned. Please try again later.");

            return createdRoom.ToCreatedRoom();
        }
    }
}