using System.Linq;
using System.Threading.Tasks;
using Discordbot.Core;
using DiscordBot.Dragonball.Domain.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace DiscordBot.Commands.Dragonball
{
    public class DragonballModule : BaseCommandModule
    {
        public DragonballModule(GetRandomCharacters getRandomCharacters)
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
            var withColor = argument switch
            {
                "--color" => true,
                "--colors" => true,
                _ => false
            };

            var author = context.Message.Author.Mention;

            if (!string.IsNullOrWhiteSpace(argument) && !withColor)
            {
                await context.RespondAsync(
                    $"You ({author}) used a wrong argument. Use --color or --colors to get a randomized color.");
                return;
            }

            var characters = GetRandomCharacters.Execute(new NoParameters());

            var characterStrings =
                characters.Select(character => withColor ? character.ToStringWithColor() : character.ToString());

            var chosenCharacters = string.Join("\n", characterStrings);
            await context.RespondAsync($"{author} the bot has chosen:\n{chosenCharacters}");
        }
    }
}