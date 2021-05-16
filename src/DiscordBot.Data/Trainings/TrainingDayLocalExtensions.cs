using System;
using System.Collections.Generic;
using System.Linq;
using DiscordBot.Data.Trainings.Models;
using DiscordBot.Domain.Trainings.Entities;

namespace DiscordBot.Data.Trainings
{
    public static class TrainingDayLocalExtensions
    {
        public static TrainingsDay ToTrainingsDay(
            this TrainingDayLocal trainingDayLocal,
            DateTime date)
        {
            return new(
                date,
                trainingDayLocal.WarmUpTraining?.ToTraining(),
                trainingDayLocal.MandatoryTrainings.ToTrainings(),
                trainingDayLocal.OptionalTrainings.ToTrainings(),
                trainingDayLocal.CoolDownTraining?.ToTraining()
            );
        }

        private static Training ToTraining(this TrainingLocal trainingLocal)
        {
            var (name, link) = trainingLocal;
            return new Training(name, link);
        }

        private static List<Training> ToTrainings(this IEnumerable<TrainingLocal> trainingsLocal)
        {
            return trainingsLocal.Select(ToTraining).ToList();
        }
    }
}