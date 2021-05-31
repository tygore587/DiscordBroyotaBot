using System;
using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Data.Trainings.DataSources.Local.IgorVoitenko;
using DiscordBot.Data.Trainings.Models;
using DiscordBot.Domain.Trainings.Entities;

namespace DiscordBot.Data.Trainings.DataSources.Local
{
    public class TrainingLocalDataSource : ITrainingLocalDataSource
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IIgorVoitenkoProvider _igorVoitenkoProvider;

        private readonly ITrainingsStartProvider _trainingsStartProvider;

        public TrainingLocalDataSource(
            IIgorVoitenkoProvider igorVoitenkoProvider,
            IDateTimeProvider dateTimeProvider,
            ITrainingsStartProvider trainingsStartProvider)
        {
            _igorVoitenkoProvider = igorVoitenkoProvider;
            _dateTimeProvider = dateTimeProvider;
            _trainingsStartProvider = trainingsStartProvider;
        }

        public TrainingsDay GetActualTraining(long day, TrainingType type)
        {
            var trainings = type switch
            {
                TrainingType.IgorFrom0To100 => _igorVoitenkoProvider.From0To100Trainings(),
                _ => _igorVoitenkoProvider.From0To100Trainings()
            };

            var calculatedDay = day % trainings.Count;

            calculatedDay = calculatedDay > 0 ? calculatedDay : day;

            return trainings.ContainsKey(calculatedDay)
                ? trainings[calculatedDay].ToTrainingsDay(_dateTimeProvider.Today())
                : TrainingDayLocal.RestDay.ToTrainingsDay(_dateTimeProvider.Today());
        }

        public DateTime GetTrainingsStart(TrainingType type)
        {
            return type switch
            {
                TrainingType.IgorFrom0To100 => _trainingsStartProvider.GetIgor0To100TrainingsStart,
                _ => _trainingsStartProvider.GetIgor0To100TrainingsStart
            };
        }
    }
}