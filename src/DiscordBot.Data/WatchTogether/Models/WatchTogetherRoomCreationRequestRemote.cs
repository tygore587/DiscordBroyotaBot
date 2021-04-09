using Newtonsoft.Json;

namespace DiscordBot.Data.WatchTogether.Models
{
    [JsonObject]
    internal class WatchTogetherRoomCreationRequestRemote
    {
        public WatchTogetherRoomCreationRequestRemote(string watchTogetherApiKey)
        {
            WatchTogetherApiKey = watchTogetherApiKey;
        }

        [JsonProperty("w2g_api_key")]
        [JsonRequired]
        public string WatchTogetherApiKey { get; set; }

        [JsonProperty("share")]
        public string? Share { get; init; }

        [JsonProperty("bg_color")]
        public string? BackgroundColor { get; init; }

        [JsonProperty("bg_opacity")]
        public string? BackgroundOpacity { get; init; }
    }
}