﻿using System;
using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Trainings.Entities;
using DiscordBot.Domain.Trainings.UseCases;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace DiscordBot.Commands.Modules.Slash
{
    public class TrainingsSlashModule : SlashCommandModule
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
            long day = -1)
        {
            try
            {
                await context.SendWorkPendingResponse();

                var parameter = new GetTodayTrainingParameter(day, TrainingType.IgorFrom0To100);

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
            var (_, trainingsDay, watchTogetherRoom) = trainingsResult;

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

            var (trainingDay, training, watchTogetherRoom) = trainingsResult;

            embedBuilder.WithTitle($"Day {trainingDay}");

            if (training.IsRestDay)
            {
                embedBuilder.WithImageUrl(
                    "https://thumb.tildacdn.com/tild3533-3333-4464-a635-356533383363/-/resize/300x/-/format/webp/photo.jpg");

                embedBuilder.WithDescription("You are good for today. Today is a rest day! Enjoy.");

                return embedBuilder.Build();
            }

            embedBuilder.WithDescription(
                "Please use the watch together room to prepare it yourself. WatchTogether doesn't allow something like this at the moment.");

            embedBuilder.WithImageUrl(
                "https://thumb.tildacdn.com/tild3463-3938-4433-a666-643537343731/-/resize/400x/-/format/webp/from_0_100.jpg");

            embedBuilder.WithUrl(trainingsResult.WatchTogetherRoom?.RoomLink);

            embedBuilder.AddField("WatchTogether Room", watchTogetherRoom?.RoomLink);

            var warmUp = training.WarmUpTraining;

            if (warmUp != null)
                embedBuilder.AddField(warmUp.Name, warmUp.Link);

            training.MandatoryTrainings.ForEach(mandatoryTraining =>
                embedBuilder.AddField(mandatoryTraining.Name, mandatoryTraining.Link));

            training.OptionsTrainings.ForEach(optionalTraining =>
                embedBuilder.AddField(optionalTraining.Name, optionalTraining.Link));

            var coolDownTraining = training.CoolDownTraining;

            if (coolDownTraining != null)
                embedBuilder.AddField(coolDownTraining.Name, coolDownTraining.Link);

            return embedBuilder.Build();
        }
    }
}