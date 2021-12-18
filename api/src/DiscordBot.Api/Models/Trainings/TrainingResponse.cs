using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.Trainings
{
    public class TrainingResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("link")]
        public string Link { get; set; } = string.Empty;
    }
}
