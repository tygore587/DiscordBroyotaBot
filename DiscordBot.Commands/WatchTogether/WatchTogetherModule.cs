using Discordbot.Core;
using DiscordBot.WatchTogether.Domain.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordBot.Commands.WatchTogether
{
    public class WatchTogetherModule : BaseCommandModule
    {
        private static readonly Regex YoutubeLinkRegex = new(@"(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?");

        private static readonly string WatchTogehterBaseUrl = "https://w2g.tv/rooms/";

        private readonly CreateWatchTogetherRoom CreateWatchTogetherRoom;

        public WatchTogetherModule(CreateWatchTogetherRoom createWatchTogetherRoom)
        {
            CreateWatchTogetherRoom = createWatchTogetherRoom;
        }

        [Command("watchtogether")]
        [Aliases("youtube","wt")]
        [Description("This creates a watch together room.")]
        public async Task RandomMemeApi(
            CommandContext context,
            [Description("Add a youtube link if this video should be loaded at start.")] string youtubeLink = null)
        {
            var author = context.Message.Author.Mention;
            try
            {
                if (!string.IsNullOrWhiteSpace(youtubeLink) && !YoutubeLinkRegex.IsMatch(youtubeLink))
                    throw new ArgumentValidationException($"{youtubeLink} this isn't a youtube link. Please initiate with a youtube link or without any link.");
               
                var createRoomParameter = new CreateWatchTogehterRoomParameters()
                {
                    YoutubeLink = youtubeLink,
                };

                var createdRoom = await CreateWatchTogetherRoom.Execute(createRoomParameter);

                if (string.IsNullOrWhiteSpace(createdRoom?.StreamKey))
                    throw new Exception("No room was created.");

                await context.RespondAsync(content: $"{author} Have fun with the room: {WatchTogehterBaseUrl}{createdRoom.StreamKey}");
            }
            catch (ArgumentValidationException ex)
            {
                await context.RespondAsync($"{author} {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await context.RespondAsync($"{author} An unexpected error occures. {ex.Message}");
            }
        }
    }
}


