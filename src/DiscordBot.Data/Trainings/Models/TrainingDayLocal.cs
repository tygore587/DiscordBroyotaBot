using System.Collections.Generic;

namespace DiscordBot.Data.Trainings.Models
{
    public record TrainingDayLocal
    (
        TrainingLocal? WarmUpTraining,
        List<TrainingLocal> MandatoryTrainings,
        List<TrainingLocal> OptionalTrainings,
        TrainingLocal? CoolDownTraining
    )
    {
        public TrainingDayLocal(
            TrainingLocal? warmUpTraining,
            List<TrainingLocal> mandatoryTrainings,
            TrainingLocal? coolDownTraining
        ) : this(warmUpTraining, mandatoryTrainings, new List<TrainingLocal>(), coolDownTraining)
        {
        }

        public static TrainingDayLocal RestDay =>
            new(null, new List<TrainingLocal>(), new List<TrainingLocal>(), null);
    }
}