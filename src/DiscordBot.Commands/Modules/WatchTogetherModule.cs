using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DiscordBot.Commands.Exceptions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.WatchTogether.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable ClassNeverInstantiated.Global

namespace DiscordBot.Commands.Modules
{
    public class WatchTogetherModule : BaseCommandModule
    {
        private const string WatchTogetherBaseUrl = "https://w2g.tv/rooms/";

        private static readonly Regex YoutubeLinkRegex =
            new(@"(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?");

        private readonly CreateWatchTogetherRoom _createWatchTogetherRoom;

        private readonly ICommandLogger _logger;

        public WatchTogetherModule(CreateWatchTogetherRoom createWatchTogetherRoom, ICommandLogger logger)
        {
            _createWatchTogetherRoom = createWatchTogetherRoom;
            _logger = logger;
        }

        [Command("watchtogether")]
        [Aliases("youtube", "wt")]
        [Description("This creates a watch together room.")]
        public async Task RandomMemeApi(
            CommandContext context,
            [Description("Add a youtube link if this video should be loaded at start.")]
            string youtubeLink = "")
        {
            var author = context.Message.Author.Mention;

            try
            {
                if (!string.IsNullOrWhiteSpace(youtubeLink) && !YoutubeLinkRegex.IsMatch(youtubeLink))
                    throw new ArgumentValidationException(
                        $"{youtubeLink} this isn't a youtube link. Please initiate with a youtube link or without any link.");

                var createRoomParameter = new CreateWatchTogetherRoomParameters(youtubeLink);

                var createdRoom = await _createWatchTogetherRoom.Execute(createRoomParameter);

                if (string.IsNullOrWhiteSpace(createdRoom.StreamKey))
                    throw new Exception("No room was created.");

                await context.RespondAsync(
                    $"{author} Have fun with the room: {WatchTogetherBaseUrl}{createdRoom.StreamKey}");
            }
            catch (ArgumentValidationException ex)
            {
                _logger.Error(ex, context, "Error while processing watch together command. Youtube-Link: {youtubeLink}",
                    youtubeLink);

                await context.RespondAsync($"{author} {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, context, "Error while processing watch together command. Youtube-Link: {youtubeLink}",
                    youtubeLink);

                Console.WriteLine(ex.Message);
                await context.RespondAsync($"{author} An unexpected error occurs. {ex.Message}");
            }
        }
    }
}