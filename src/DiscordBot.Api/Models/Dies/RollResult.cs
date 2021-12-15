using Newtonsoft.Json;

namespace DiscordBot.Api.Models.Dies
{
    [JsonObject]
    public class RollResult
    {
        [JsonProperty("eyes")]
        public int Eyes { get; set; }
    }
}
