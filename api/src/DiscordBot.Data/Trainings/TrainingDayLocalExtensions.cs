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
            var optionalTrainings = trainingDayLocal.Trainings.Where(training => training is OptionalTrainingLocal).ToList();

            return new(
                date,
                trainingDayLocal.WarmUp?.ToTraining(),
                trainingDayLocal.Trainings.Except(optionalTrainings).ToTrainings(),
                optionalTrainings.ToTrainings(),
                trainingDayLocal.Cooldown?.ToTraining()
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