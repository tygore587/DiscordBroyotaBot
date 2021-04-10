using System;
using System.Threading.Tasks;
using DiscordBot.Core.Constants;
using DiscordBot.Data.Models.Remote.WatchTogether;

namespace DiscordBot.Data.DataSources.Remote.WatchTogether
{
    internal class WatchTogetherRemoteDataSource : IWatchTogetherRemoteDataSource
    {
        private readonly IWatchTogetherApi _watchTogetherApi;

        public WatchTogetherRemoteDataSource(IWatchTogetherApi watchTogetherApi)
        {
            _watchTogetherApi = watchTogetherApi;
        }

        public async Task<WatchTogetherRoomRemote> CreateWatchTogetherRoom(string? youtubeLink = null)
        {
            if (string.IsNullOrWhiteSpace(EnvironmentVariables.WatchTogetherApiKey))
                throw new ArgumentNullException(nameof(EnvironmentVariables.WatchTogetherApiKey),
                    "Watch together api key was null or empty.");

            var createRoomBody = new WatchTogetherRoomCreationRequestRemote(EnvironmentVariables.WatchTogetherApiKey)
            {
                BackgroundColor = "#131313",
                Share = youtubeLink
            };

            return await _watchTogetherApi.CreateRoom(createRoomBody);
        }
    }
}