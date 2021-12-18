

using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.Trainings
{
    public class TrainingDayResponse
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("warumUpTraining")]
        public TrainingResponse? WarmUpTraining { get; set; }

        [JsonPropertyName("mandatoryTrainings")]
        public List<TrainingResponse> MandatoryTrainings { get; set; } = new();

        [JsonPropertyName("optionalTrainings")]
        public List<TrainingResponse> OptionalTraning { get; set; } = new();

        [JsonPropertyName("coolDownTraining")]
        public TrainingResponse? CoolDownTraining { get; set; }

        [JsonPropertyName("restday")]
        public bool RestDay { get; set; }

    }
}
