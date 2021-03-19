using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Core.Constants;
using DiscordBot.Data.Requests;
using DiscordBot.Data.WatchTogether.Models;

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

        public async Task<CreatedRoomRemote> CreateWatchTogetherRoom(string? youtubeLink = null)
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

            return createdRoom;
        }
    }
}