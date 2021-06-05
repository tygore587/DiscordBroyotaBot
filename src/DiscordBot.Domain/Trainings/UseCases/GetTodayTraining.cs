﻿using System.Threading.Tasks;
using DiscordBot.Core;
using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Core.DateTimes;
using DiscordBot.Domain.Trainings.Entities;
using DiscordBot.Domain.Trainings.Repositories;
using DiscordBot.Domain.WatchTogether.Repositories;

namespace DiscordBot.Domain.Trainings.UseCases
{
    public class GetTodayTraining : IUseCase<Task<TrainingsResult>, GetTodayTrainingParameter>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ITrainingsRepository _trainingsRepository;

        private readonly IWatchTogetherRepository _watchTogetherRepository;

        public GetTodayTraining(
            ITrainingsRepository trainingsRepository,
            IDateTimeProvider dateTimeProvider,
            IWatchTogetherRepository watchTogetherRepository)
        {
            _trainingsRepository = trainingsRepository;
            _dateTimeProvider = dateTimeProvider;
            _watchTogetherRepository = watchTogetherRepository;
        }

        public async Task<TrainingsResult> Execute(GetTodayTrainingParameter parameters)
        {
            var dayOfTraining = GetDayOfTraining(parameters);

            var trainingForToday = _trainingsRepository.GetTrainingForDay(dayOfTraining, parameters.Type);

            if (trainingForToday.TrainingsDay.IsRestDay)
                return new TrainingsResult(dayOfTraining, trainingForToday, null);

            var watchTogetherRoom = await _watchTogetherRepository.CreateWatchTogetherRoom();

            return new TrainingsResult(dayOfTraining, trainingForToday, watchTogetherRoom);
        }

        private long GetDayOfTraining(GetTodayTrainingParameter parameters)
        {
            var (day, trainingType) = parameters;

            if (day > 0)
                return day;

            var trainingsStart = _trainingsRepository.GetTrainingsStart(trainingType);

            return (_dateTimeProvider.UtcNow().ConvertToCest() - trainingsStart).Days + 1;
        }
    }

    public record GetTodayTrainingParameter(long Day, TrainingType Type);
}