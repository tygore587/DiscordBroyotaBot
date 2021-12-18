using DiscordBot.Api.Models.WatchTogether;
using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.Trainings
{
    public class TrainingResultResponse
    {
        [JsonPropertyName("day")]
        public long Day { get; set; }

        [JsonPropertyName("plan")]
        public TrainingsPlanResponse? TrainingsPlan { get; set; }

        [JsonPropertyName("room")]
        public SharedRoom? Room { get; set; }
    }
}
