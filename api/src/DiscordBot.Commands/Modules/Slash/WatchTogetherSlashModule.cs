using DisCatSharp.ApplicationCommands;
using DisCatSharp.ApplicationCommands.Attributes;
using DisCatSharp.ApplicationCommands.Context;
using DiscordBot.Commands.Exceptions;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.WatchTogether.UseCases;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Modules.Slash
{
    public class WatchTogetherSlashModule : ApplicationCommandsModule
    {
        private static readonly Regex YoutubeLinkRegex =
            new(@"(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?");

        private static readonly Regex TwitchLinkRegex =
            new(@"^(?:https?:\/\/)?(?:www\.|go\.)?twitch\.tv\/([a-zA-Z0-9_]+)($|\?)");

        private readonly CreateWatchTogetherRoom _createWatchTogetherRoom;

        private readonly ICommandLogger _logger;

        public WatchTogetherSlashModule(CreateWatchTogetherRoom createWatchTogetherRoom, ICommandLogger logger)
        {
            _createWatchTogetherRoom = createWatchTogetherRoom;
            _logger = logger;
        }

        [SlashCommand("wt", "this creates a watch together room.")]
        public async Task CreateWatchTogetherRoom(
            InteractionContext context,
            [Option("youtubeOrTwitchLink", "add a youtube or twitch link if this video should be loaded at start.")]
            string? youtubeOrTwitchLink = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(youtubeOrTwitchLink) && !YoutubeLinkRegex.IsMatch(youtubeOrTwitchLink) &&
                    !TwitchLinkRegex.IsMatch(youtubeOrTwitchLink))
                    throw new ArgumentValidationException(
                        $"{youtubeOrTwitchLink} this isn't a youtube or twitch link. Please initiate with a youtube or twitch link or without any link.");

                await context.SendWorkPendingResponse();

                var createRoomParameter = new CreateWatchTogetherRoomParameters(youtubeOrTwitchLink);

                var createdRoom = await _createWatchTogetherRoom.Execute(createRoomParameter);

                if (string.IsNullOrWhiteSpace(createdRoom.RoomLink))
                    throw new NoRoomCreatedException("No room was created.");

                await context.SendWorkFinishedResponse(
                    $"Have fun with the room: {createdRoom.RoomLink}");
            }
            catch (Exception ex)
            {
                string messageTemplate = "Error while processing watch together command.";

                if (!string.IsNullOrWhiteSpace(youtubeOrTwitchLink))
                    messageTemplate += "{YoutubeOrTwitchLink}";

                if (string.IsNullOrWhiteSpace(youtubeOrTwitchLink))
                    _logger.Error(ex, context, messageTemplate);
                else
                    _logger.Error(ex, context, messageTemplate, youtubeOrTwitchLink);

                if (ex is ArgumentValidationException)
                {
                    await context.RespondWithError(ex.Message);
                    return;
                }

                await context.SendWorkFinishedResponse($"An unexpected error occurs. {ex.Message}");
            }
        }
    }
}