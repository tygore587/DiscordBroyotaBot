using DiscordBot.Api.Controllers.WatchTogether;
using DiscordBot.Api.Models.Trainings;
using DiscordBot.Domain.Trainings.Entities;

namespace DiscordBot.Api.Controllers.Trainings
{
    public static class TrainingsExtensions
    {
        public static TrainingType ToTraingsType(this TrainingsPlan trainingsPlan)
        {
            return trainingsPlan switch
            {
                TrainingsPlan.IgorFrom0To100 => TrainingType.IgorFrom0To100,
                TrainingsPlan.SaschaHuberPlan1Starter => TrainingType.SaschaHuberPlan1Starter,
                _ => TrainingType.SaschaHuberPlan1Starter,
            };
        }


        public static TrainingResultResponse ToTrainingResultResponse(this TrainingsResult trainingsResult)
        {
            return new TrainingResultResponse
            {
                Day = trainingsResult.Day,
                Room = trainingsResult.WatchTogetherRoom?.ToSharedRoom(),
                TrainingsPlan = trainingsResult.TrainingsDay.ToTrainingsPlanResponse(),
            };
        }

        private static TrainingsPlanResponse ToTrainingsPlanResponse(this TrainingsPlanDay trainingsPlanDay)
        {
            return new TrainingsPlanResponse
            {
                ImageUrl = trainingsPlanDay.ImageUrl,
                TrainingsPlanUrl = trainingsPlanDay.TrainingsUrl,
                TrainingsDay = trainingsPlanDay.TrainingsDay.ToTrainingDayResponse(),
            };
        }

        private static TrainingDayResponse ToTrainingDayResponse(this TrainingsDay trainingsDay)
        {
            return new TrainingDayResponse
            {
                CoolDownTraining = trainingsDay.CoolDownTraining.ToTrainingResponse(),
                Date = trainingsDay.Date,
                MandatoryTrainings = trainingsDay.MandatoryTrainings.ToTrainingResponse(),
                OptionalTraning = trainingsDay.OptionsTrainings.ToTrainingResponse(),
                RestDay = trainingsDay.IsRestDay,
                WarmUpTraining = trainingsDay.WarmUpTraining.ToTrainingResponse(),
            };
        }

        private static List<TrainingResponse> ToTrainingResponse(this IEnumerable<Training?>? trainings)
        {
            return trainings?.Where(t => t != null).Select(t => t!.ToTrainingResponse()).ToList() ?? new();
        }

        private static TrainingResponse? ToTrainingResponse(this Training? training)
        {
            return training == null
                ? null
                : new TrainingResponse
                {
                    Link = training.Link,
                    Name = training.Name,
                };

        }
    }
}
