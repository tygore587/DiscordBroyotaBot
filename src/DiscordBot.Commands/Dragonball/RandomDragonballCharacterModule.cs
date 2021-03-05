using System.Linq;
using System.Threading.Tasks;
using Discordbot.Core;
using DiscordBot.Domain.Dragonball.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace DiscordBot.Commands.Dragonball
{
    public class RandomDragonballCharacterModule : BaseCommandModule
    {
        public RandomDragonballCharacterModule(GetRandomCharacters getRandomCharacters)
        {
            GetRandomCharacters = getRandomCharacters;
        }

        private GetRandomCharacters GetRandomCharacters { get; }

        [Command("dbzRandom")]
        [Description(
            "This returns 3 random characters with assists for the game Dragonball FighterZ. If you want to have random colors, please add --colors as an argument.")]
        [RequireGuild]
        public async Task GetRandomCharacterChoice(CommandContext context,
            [Description("Use --color to also get random color.")]
            string argument = "")
        {
            var author = context.Message.Author.Mention;

            try
            {
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

                var characters = GetRandomCharacters.Execute(characterParams);

                var characterStrings =
                    characters.Select(character => !withColor ? character.ToString() : character.ToStringWithColor());

                var chosenCharacters = string.Join("\n", characterStrings);
                await context.RespondAsync($"{author} the bot has chosen:\n{chosenCharacters}");
            }
            catch (ArgumentValidationException ex)
            {
                await context.RespondAsync($"{author} {ex.Message}");
            }
        }
    }
}