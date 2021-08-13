using System.Collections.Generic;

namespace DiscordBot.Data.Trainings.Models
{
    public record TrainingDayLocal
    (
        TrainingLocal? WarmUp,
        List<TrainingLocal> Trainings,
        TrainingLocal? Cooldown = null
    )
    {
        public static TrainingDayLocal RestDay =>
            new(null, new List<TrainingLocal>());
    }
}