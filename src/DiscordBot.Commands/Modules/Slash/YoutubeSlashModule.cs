using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Youtube.Entities;
using DiscordBot.Domain.Youtube.UseCases;
using DSharpPlus.SlashCommands;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Modules.Slash
{
    [SlashCommandGroup("youtube", "Get video from youtube")]
    public class YoutubeSlashModule : ApplicationCommandModule
    {
        private readonly ICommandLogger _logger;

        private readonly SearchNewestVideoFromChannel SearchNewestVideoFromChannel;

        public YoutubeSlashModule(ICommandLogger logger, SearchNewestVideoFromChannel searchNewestVideoFromChannel)
        {
            _logger = logger;
            SearchNewestVideoFromChannel = searchNewestVideoFromChannel;
        }

        [SlashCommand("tagesschau", "Get the current tagesschau links.")]
        public async Task GetCurrentTagesschau(InteractionContext context)
        {
            try
            {
                await context.SendWorkPendingResponse();

                var parameter = new SearchNewestVideoParameter(YoutubeChannelIds.Tagesschau, "tagesschau 20");

                var videoResult = await SearchNewestVideoFromChannel.Execute(parameter);

                var message =
                    videoResult.LatestFoundVideo == null
                        ? "No video was found."
                        : videoResult.FoundVideoFromToday
                            ? $"{videoResult.LatestFoundVideo.Link}"
                            : $"**No video for today was found.**\nLast video found: {videoResult.LatestFoundVideo.Link}";

                await context.SendWorkFinishedResponse(message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, context, "Error while processing news command.");

                await context.SendWorkFinishedResponse(
                    $"An unexpected error occurs. {ex.Message}");
            }
        }
    }
}
