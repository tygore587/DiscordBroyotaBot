using System;
using System.Threading.Tasks;
using DiscordBot.Dice.Domain.Models;
using DiscordBot.Dice.Domain.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot.Commands.Dice
{
    [Description("All dices commands.")]
    public class DiceModule : BaseCommandModule
    {
        [Command("roll")]
        [Description("This rolls a die with sides.")]
        [RequireGuild]
        public async Task RollDie(CommandContext context, [Description("Number of sides")] int sides = 20)
        {
            if (sides <= 0 || sides > 100)
            {
                await context.RespondAsync(
                    $"{context.Message.Author.Mention} your die must have between 1 and 100 sides.");
                return;
            }

            var die = new Die(new Random());

            var rollDice = new RollDice(die);

            var parameters = new DieParameter
            {
                Sides = sides
            };

            var side = rollDice.Execute(parameters);

            await context.RespondAsync($"{context.Message.Author.Mention} you rolled **{side}**.");
        }
    }
}