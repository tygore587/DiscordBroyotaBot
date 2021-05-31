using System;
using DiscordBot.Domain.Trainings.Entities;

namespace DiscordBot.Domain.Trainings.Repositories
{
    public interface ITrainingsRepository
    {
        TrainingsPlanDay GetTrainingForDay(long day, TrainingType type);
        DateTime GetTrainingsStart(TrainingType type);
    }
}