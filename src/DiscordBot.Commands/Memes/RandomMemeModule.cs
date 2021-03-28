using System;
using System.Threading.Tasks;
using DiscordBot.Commands.Exceptions;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Memes.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace DiscordBot.Commands.Memes
{
    public class RandomMemeModule : BaseCommandModule
    {
        private readonly GetRandomMeme _getRandomMeme;

        private readonly ICommandLogger _logger;

        public RandomMemeModule(GetRandomMeme getRandomMeme, ICommandLogger logger)
        {
            _getRandomMeme = getRandomMeme;
            _logger = logger;
        }

        [Command("meme")]
        [Description("This returns a random meme from an api. Use --nsfw to include nfsw content.")]
        public async Task RandomMemeApi(CommandContext context, string argument = "")
        {
            var author = context.GetAuthorMention();
            try
            {
                var withNfsw = argument.ToLower() switch
                {
                    "" => false,
                    "--nsfw" => true,
                    _ => throw new ArgumentValidationException("Argument is wrong, please use --nfsw or no argument.")
                };

                var randomMemeParams = new RandomMemeParameters
                {
                    IncludeNsfw = withNfsw
                };

                var randomMeme = await _getRandomMeme.Execute(randomMemeParams);

                if (randomMeme == null)
                    throw new Exception("No random meme was found on api.");

                var embed = new DiscordEmbedBuilder()
                    .WithTitle(randomMeme.Title)
                    .WithUrl(randomMeme.PostLink)
                    .WithImageUrl(randomMeme.Url);

                //TODO: Add counter for successful calls instead of log messages?
                _logger.Information(context, "Successfully processed random meme command.");

                await context.RespondAsync($"{author}", embed: embed);
            }
            catch (ArgumentValidationException ex)
            {
                _logger.Error(ex, context,
                    "Error while processing random meme command. Argument: {argument} | Bla: {bla}",
                    argument, "bla");

                await context.RespondAsync($"{author} {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, context,
                    "Error while processing random meme command. Argument: {argument} | Bla: {bla}",
                    argument, "bla");

                await context.RespondAsync($"{author} An unexpected error occurs.");
            }
        }
    }
}