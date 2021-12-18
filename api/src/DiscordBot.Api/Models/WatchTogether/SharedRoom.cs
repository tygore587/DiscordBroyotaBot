using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.WatchTogether
{
    
    public class SharedRoom
    {
        [JsonPropertyName("link")]
        public string Link { get; set; } = string.Empty;
    }
}
