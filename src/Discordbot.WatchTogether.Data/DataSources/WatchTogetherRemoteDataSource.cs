using Discordbot.WatchTogether.Data.Extensions;
using Discordbot.WatchTogether.Data.Models;
using DiscordBot.Core.Constants;
using DiscordBot.Core.Data.Requests;
using DiscordBot.WatchTogether.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Discordbot.WatchTogether.Data.DataSources
{
    public class WatchTogetherRemoteDataSource : IWatchTogetherRemoteDataSource
    {
        private const string BaseUrl = "https://w2g.tv/";

        public IRequestClient RequestClient;

        public WatchTogetherRemoteDataSource(IRequestClient requestClient)
        {
            RequestClient = requestClient;
        }

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string youtubeLink = null)
        {
            if (string.IsNullOrWhiteSpace(EnvironmentVariables.WatchTogetherApiKey))
                throw new ArgumentNullException(nameof(EnvironmentVariables.WatchTogetherApiKey), "Watch together api key was null or empty.");

            var createRoomBody = new RoomCreationRemote
            {
                BackgroundColor = "#131313",
                Share = youtubeLink,
                WatchTogetherApiKey = EnvironmentVariables.WatchTogetherApiKey,
            };

            var createdRoom = await RequestClient.PostJsonAsync<RoomCreationRemote, CreatedRoomRemote>(createRoomBody, BaseUrl, paths: new() { "rooms", "create.json" });

            return createdRoom.ToCreatedRoom();
        }
    }
}