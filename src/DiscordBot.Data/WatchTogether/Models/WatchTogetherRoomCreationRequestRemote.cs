using Newtonsoft.Json;

namespace DiscordBot.Data.WatchTogether.Models
{
    [JsonObject]
    public class WatchTogetherRoomCreationRequestRemote
    {
        public WatchTogetherRoomCreationRequestRemote(string watchTogetherApiKey)
        {
            WatchTogetherApiKey = watchTogetherApiKey;
        }

        [JsonProperty("w2g_api_key", Required = Required.DisallowNull)]
        public string WatchTogetherApiKey { get; set; }

        [JsonProperty("share")]
        public string? Share { get; set; }

        [JsonProperty("bg_color")]
        public string? BackgroundColor { get; set; }

        [JsonProperty("bg_opacity")]
        public string? BackgroundOpacity { get; set; }
    }
}