using DisCatSharp.ApplicationCommands;
using DisCatSharp.ApplicationCommands.Attributes;
using DisCatSharp.ApplicationCommands.Context;
using DisCatSharp.Entities;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Trainings.Entities;
using DiscordBot.Domain.Trainings.UseCases;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Modules.Slash.Trainings
{
    public class TrainingsSlashModule : ApplicationCommandsModule
    {
        private readonly GetTodayTraining _getTodayTraining;

        private readonly ICommandLogger _logger;

        public TrainingsSlashModule(GetTodayTraining getTodayTraining, ICommandLogger logger)
        {
            _getTodayTraining = getTodayTraining;
            _logger = logger;
        }

        [SlashCommand("training", "get today's training from plan.")]
        public async Task GetTodayTraining(
            InteractionContext context,
            [Option("day", "Choose the day you want to print.")]
            int day = -1,
            [Option("traini", "test")] Trainingsplan plan = Trainingsplan.SaschaHuberPlan1Starter)
        {
            try
            {
                await context.SendWorkPendingResponse();

                var parameter = new GetTodayTrainingParameter(day, plan.ToTrainingType());

                var todayTrainingResult = await _getTodayTraining.Execute(parameter);

                if (IsToBigForEmbed(todayTrainingResult))
                {
                    await context.SendWorkFinishedResponse(
                        "Your training is to big for an embed. We currently do not support such big trainings. Please provide smaller trainings or contact developer.");

                    _logger.Information(context, "The trainings was to big for an embed and can't be printed.");

                    return;
                }

                var trainingsEmbed = CreateTrainingsEmbed(todayTrainingResult);

                await context.SendWorkFinishedResponse(trainingsEmbed);
            }
            catch (Exception ex)
            {
                const string messageTemplate = "Error while processing watch together command.";

                _logger.Error(ex, context, messageTemplate);

                await context.SendWorkFinishedResponse($"An unexpected error occurs. {ex.Message}");
            }
        }

        private static bool IsToBigForEmbed(TrainingsResult trainingsResult)
        {
            var (_, trainingsPlanDay, watchTogetherRoom) = trainingsResult;

            var trainingsDay = trainingsPlanDay.TrainingsDay;

            if (trainingsDay.IsRestDay)
                return false;

            var embedCounter = 0;

            if (!string.IsNullOrWhiteSpace(watchTogetherRoom?.RoomLink))
                embedCounter++;

            if (trainingsDay.WarmUpTraining != null)
                embedCounter++;

            embedCounter += trainingsDay.MandatoryTrainings.Count + trainingsDay.OptionsTrainings.Count;

            if (trainingsDay.CoolDownTraining != null)
                embedCounter++;

            return embedCounter > EmbeddedConstants.MaxFields;
        }

        private static DiscordEmbed CreateTrainingsEmbed(TrainingsResult trainingsResult)
        {
            var embedBuilder = new DiscordEmbedBuilder();

            var (trainingDay, (trainingsUrl, training, imageUrl), watchTogetherRoom) = trainingsResult;

            embedBuilder.WithTitle($"Day {trainingDay}");

            embedBuilder.WithUrl(trainingsUrl);

            if (training.IsRestDay)
            {
                embedBuilder.WithImageUrl(
                    "https://thumb.tildacdn.com/tild3533-3333-4464-a635-356533383363/-/resize/300x/-/format/webp/photo.jpg");

                embedBuilder.WithDescription("You are good for today. Today is a rest day! Enjoy.");

                return embedBuilder.Build();
            }

            embedBuilder.WithDescription(
                "All mandatory trainings are already added to the watch together room.");

            embedBuilder.WithImageUrl(imageUrl);

            embedBuilder.AddField("WatchTogether Room", watchTogetherRoom?.RoomLink);

            var warmUp = training.WarmUpTraining;

            if (warmUp != null)
                embedBuilder.AddField(warmUp.Name, warmUp.Link);

            training.MandatoryTrainings.ForEach(mandatoryTraining =>
                embedBuilder.AddField(mandatoryTraining.Name, mandatoryTraining.Link));

            training.OptionsTrainings.ForEach(optionalTraining =>
                embedBuilder.AddField($"{optionalTraining.Name} (optional)", optionalTraining.Link));

            var coolDownTraining = training.CoolDownTraining;

            if (coolDownTraining != null)
                embedBuilder.AddField(coolDownTraining.Name, coolDownTraining.Link);

            return embedBuilder.Build();
        }
    }
}
