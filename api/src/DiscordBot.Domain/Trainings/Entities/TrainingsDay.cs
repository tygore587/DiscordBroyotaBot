using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordBot.Domain.Trainings.Entities
{
    public record TrainingsDay
    (
        DateTime Date,
        Training? WarmUpTraining,
        List<Training> MandatoryTrainings,
        List<Training> OptionsTrainings,
        Training? CoolDownTraining
    )
    {
        public bool IsRestDay => WarmUpTraining == null && !MandatoryTrainings.Any() &&
                                 !OptionsTrainings.Any() && CoolDownTraining == null;
    }
}