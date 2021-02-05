using System.Threading.Tasks;
using DiscordBot.Dice.Domain.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot.Commands.Die
{
    public class DieModule : BaseCommandModule
    {
        [Command("roll")]
        [Description(
            "This rolls a die with sides. Use roll <numberOfSides>.")]
        [RequireGuild]
        public async Task RollDie(CommandContext context, int sides)
        {
            if (sides <= 0 || sides > 100)
            {
                await context.RespondAsync(
                    $"{context.Message.Author.Mention} your die must have between 1 and 100 sides.");
                return;
            }

            var rollDice = new RollDice();

            var parameters = new DieParameter
            {
                Sides = sides
            };

            var side = rollDice.Execute(parameters);

            await context.RespondAsync($"{context.Message.Author.Mention} you rolled **{side}**.");
        }
    }
}