using System;
using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Data.Trainings.DataSources.Local.IgorVoitenko;
using DiscordBot.Data.Trainings.DataSources.Local.SaschaHuber;
using DiscordBot.Data.Trainings.Models;
using DiscordBot.Domain.Trainings.Entities;

namespace DiscordBot.Data.Trainings.DataSources.Local
{
    public class TrainingLocalDataSource : ITrainingLocalDataSource
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IIgorVoitenkoProvider _igorVoitenkoProvider;

        private readonly ISaschaHuberProvider _saschaHuberProvider;
        private readonly ITrainingsStartProvider _trainingsStartProvider;


        public TrainingLocalDataSource(
            IIgorVoitenkoProvider igorVoitenkoProvider,
            IDateTimeProvider dateTimeProvider,
            ITrainingsStartProvider trainingsStartProvider,
            ISaschaHuberProvider saschaHuberProvider)
        {
            _igorVoitenkoProvider = igorVoitenkoProvider;
            _dateTimeProvider = dateTimeProvider;
            _trainingsStartProvider = trainingsStartProvider;
            _saschaHuberProvider = saschaHuberProvider;
        }

        public TrainingsPlanDay GetActualTraining(long day, TrainingType type)
        {
            var (trainingsUrl, trainings, imageUrl) = type switch
            {
                TrainingType.IgorFrom0To100 => _igorVoitenkoProvider.From0To100Trainings(),
                TrainingType.SaschaHuberPlan1Starter => _saschaHuberProvider.Plan1Starter(),
                _ => _igorVoitenkoProvider.From0To100Trainings()
            };

            var calculatedDay = day % trainings.Count;

            calculatedDay = calculatedDay > 0 ? calculatedDay : day;

            var trainingsDay = trainings.ContainsKey(calculatedDay)
                ? trainings[calculatedDay].ToTrainingsDay(_dateTimeProvider.Today())
                : TrainingDayLocal.RestDay.ToTrainingsDay(_dateTimeProvider.Today());

            return new TrainingsPlanDay(
                trainingsUrl,
                trainingsDay,
                imageUrl
            );
        }

        public DateTime GetTrainingsStart(TrainingType type)
        {
            return type switch
            {
                TrainingType.IgorFrom0To100 => _trainingsStartProvider.GetIgor0To100TrainingsStart,
                TrainingType.SaschaHuberPlan1Starter => _trainingsStartProvider.GetSaschaHuberPlan1StarterStart,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "No start time found.")
            };
        }
    }
}