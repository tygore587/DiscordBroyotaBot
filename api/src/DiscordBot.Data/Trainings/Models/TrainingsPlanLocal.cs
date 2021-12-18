using System.Collections.Generic;

namespace DiscordBot.Data.Trainings.Models
{
    public record TrainingsPlanLocal
    (
        string TrainingsUrl,
        Dictionary<long, TrainingDayLocal> Trainings,
        string? ImageUrl = null
    );
}