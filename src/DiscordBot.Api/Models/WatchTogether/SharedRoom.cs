using Newtonsoft.Json;

namespace DiscordBot.Api.Models.WatchTogether
{
    [JsonObject]
    public class SharedRoom
    {
        [JsonProperty("link")]
        public string Link { get; set; } = string.Empty;
    }
}
