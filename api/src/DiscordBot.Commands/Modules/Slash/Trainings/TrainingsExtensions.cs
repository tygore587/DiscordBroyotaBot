using System;
using DiscordBot.Domain.Trainings.Entities;

namespace DiscordBot.Commands.Modules.Slash.Trainings
{
    public static class TrainingsExtensions
    {
        public static TrainingType ToTrainingType(this Trainingsplan trainingsPlan)
        {
            return trainingsPlan switch
            {
                Trainingsplan.IgorFrom0To100 => TrainingType.IgorFrom0To100,
                Trainingsplan.SaschaHuberPlan1Starter => TrainingType.SaschaHuberPlan1Starter,
                _ => throw new ArgumentOutOfRangeException(nameof(trainingsPlan), trainingsPlan,
                    "Trainings plan was not found.")
            };
        }
    }
}