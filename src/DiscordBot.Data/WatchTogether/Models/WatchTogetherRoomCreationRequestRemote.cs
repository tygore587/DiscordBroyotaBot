using Newtonsoft.Json;

namespace DiscordBot.Data.WatchTogether.Models
{
    [JsonObject]
    internal record WatchTogetherRoomCreationRequestRemote
    (
        [JsonProperty("w2g_api_key", Required = Required.DisallowNull)]
        string WatchTogetherApiKey,
        [JsonProperty("share")] string? Share,
        [JsonProperty("bg_color")] string? BackgroundColor,
        [JsonProperty("bg_opacity")] string? BackgroundOpacity
    );
}