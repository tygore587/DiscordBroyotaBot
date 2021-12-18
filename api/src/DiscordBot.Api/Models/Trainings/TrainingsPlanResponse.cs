using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.Trainings
{
    public class TrainingsPlanResponse
    {
        [JsonPropertyName("trainingPlansUrl")]
        public string TrainingsPlanUrl { get; set; } = string.Empty;

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("trainingsDay")]
        public TrainingDayResponse? TrainingsDay { get; set; }
    }
}
