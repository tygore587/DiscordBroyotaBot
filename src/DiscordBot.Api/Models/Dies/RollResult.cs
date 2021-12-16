using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.Dies
{
    public class RollResult
    {
        [JsonPropertyName("eyes")]
        public int Eyes { get; set; }
    }
}
