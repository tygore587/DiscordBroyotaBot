using DisCatSharp.ApplicationCommands;
using DisCatSharp.ApplicationCommands.Attributes;
using DisCatSharp.ApplicationCommands.Context;
using DisCatSharp.Entities;
using DiscordBot.Commands.Exceptions;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Memes.UseCases;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Modules.Slash
{
    public class RedditMemeSlashModule : ApplicationCommandsModule
    {
        private readonly GetRandomMeme _getRandomMeme;

        private readonly ICommandLogger _logger;

        public RedditMemeSlashModule(GetRandomMeme getRandomMeme, ICommandLogger logger)
        {
            _getRandomMeme = getRandomMeme;
            _logger = logger;
        }

        //TODO: add Argument for subreddit
        [SlashCommand("redditmeme", "this returns a random meme from an api.")]
        public async Task PostRandomMeme(InteractionContext context,
            [Option("includeNsfw", "set to true if nsfw content is allowed. Default is false")]
            bool includeNsfw = false)
        {
            var author = context.GetAuthorMention();
            try
            {
                await context.SendWorkPendingResponse();

                var randomMemeParams = new RandomMemeParameters
                {
                    IncludeNsfw = includeNsfw
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

                await context.SendWorkFinishedResponse(embed);
            }
            catch (ArgumentValidationException ex)
            {
                _logger.Error(ex, context,
                    "Error while processing random meme command.");

                await context.SendWorkFinishedResponse($"{author} {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, context,
                    "Error while processing random meme command.");

                await context.SendWorkFinishedResponse($"{author} An unexpected error occurs. {ex.Message}");
            }
        }
    }
}