using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Commands.Exceptions;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Dragonball.Entities;
using DiscordBot.Domain.Dragonball.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace DiscordBot.Commands.Modules
{
    public class RandomDragonballCharacterModule : BaseCommandModule
    {
        private readonly GetRandomCharacters _getRandomCharacters;
        private readonly ICommandLogger _logger;

        public RandomDragonballCharacterModule(GetRandomCharacters getRandomCharacters, ICommandLogger logger)
        {
            _getRandomCharacters = getRandomCharacters;
            _logger = logger;
        }


        [Command("dbzRandom")]
        [Description(
            "This returns 3 random characters with assists for the game Dragonball FighterZ. If you want to have random colors, please add --colors as an argument.")]
        [RequireGuild]
        public async Task GetRandomCharacterChoice(CommandContext context,
            [Description("Use --color to also get random color.")]
            string argument = "")
        {
            try
            {
                await context.TriggerTypingAsync();

                var withColor = argument switch
                {
                    "--color" => true,
                    "--colors" => true,
                    "" => false,
                    _ => throw new ArgumentValidationException("Argument is wrong, please use --color or no argument.")
                };

                var characterParams = new RandomCharacterParams
                {
                    Count = 3
                };

                var characters = _getRandomCharacters.Execute(characterParams);

                _logger.Information(context, "Successfully got dragonball characters. {@characters}", characters);

                var embed = CreateRandomCharacterEmbed(characters, withColor);

                await context.RespondAsync($"{context.GetAuthorMention()} The bot has chosen:", embed: embed);
            }
            catch (ArgumentValidationException ex)
            {
                _logger.Error(ex, context, "Error while processing dragonball command.");

                await context.RespondAsync($"{context.GetAuthorMention()} {ex.Message}");
            }
        }

        private static DiscordEmbed CreateRandomCharacterEmbed(List<DragonballCharacter> dragonballCharacters,
            bool withColor)
        {
            var embedBuilder = new DiscordEmbedBuilder();

            embedBuilder.WithAuthor("Random Characters");

            embedBuilder.WithThumbnail(
                "https://cdn.akamai.steamstatic.com/steam/apps/678950/header.jpg?t=1617120109");

            dragonballCharacters.ForEach(character =>
            {
                var (name,
                    assist,
                    color) = character;

                var text = $"Assist: {assist}";

                if (withColor)
                    text += $"\nColor: {color}";

                embedBuilder.AddField(name, text);
            });

            return embedBuilder.Build();
        }
    }
}