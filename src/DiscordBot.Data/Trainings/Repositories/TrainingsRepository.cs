using System;
using DiscordBot.Data.Trainings.DataSources.Local;
using DiscordBot.Domain.Trainings.Entities;
using DiscordBot.Domain.Trainings.Repositories;

namespace DiscordBot.Data.Trainings.Repositories
{
    public class TrainingsRepository : ITrainingsRepository
    {
        private readonly ITrainingLocalDataSource _localDataSource;

        public TrainingsRepository(
            ITrainingLocalDataSource localDataSource)
        {
            _localDataSource = localDataSource;
        }

        public TrainingsDay GetTrainingForDay(long day, TrainingType type)
        {
            return _localDataSource.GetActualTraining(day, type);
        }

        public DateTime GetTrainingsStart(TrainingType type)
        {
            return _localDataSource.GetTrainingsStart(type);
        }
    }
}