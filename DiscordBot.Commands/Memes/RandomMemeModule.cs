using Discordbot.Core;
using Discordbot.Memes.Domain.Usecases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Memes
{
    public class RandomMemeModule : BaseCommandModule
    {
        private GetRandomMeme GetRandomMeme;

        public RandomMemeModule(GetRandomMeme getRandomMeme)
        {
            GetRandomMeme = getRandomMeme;
        }

        [Command("meme")]
        [Description("This returns a random meme from an api. Use --nfsw to include nfsw content.")]
        public async Task RandomMemeApi(CommandContext context, string argument = "")
        {
            var author = context.Message.Author.Mention;
            try
            {
                var withNFSW = argument.ToLower() switch
                {
                    "" => false,
                    "--nfsw" => true,
                    _ => throw new ArgumentValidationException("Argument is wrong, please use --nfsw or no argument.")
                };

                var randomMemeParams = new RandomMemeParameters()
                {
                    IncludeNSFW = withNFSW,
                };

                var randomMeme = await GetRandomMeme.Execute(randomMemeParams);

                if (randomMeme == null)
                    throw new Exception("No random meme was found on api.");

                var embed = new DiscordEmbedBuilder()
                    .WithTitle(randomMeme.Title)
                    .WithImageUrl(randomMeme.Url);

                await context.RespondAsync(content: $"{author} From: {randomMeme.PostLink}", embed: embed);
            }
            catch (ArgumentValidationException ex)
            {
                await context.RespondAsync($"{author} {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await context.RespondAsync($"{author} An unexpected error occures.");
            }
        }
    }
}