﻿using DiscordBot.Dice.Domain.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Dice
{
    [Description("All dices commands.")]
    public class DiceModule : BaseCommandModule
    {
        private RollDice RollDice;

        public DiceModule(RollDice rollDice)
        {
            RollDice = rollDice;
        }

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

            var parameters = new DieParameter
            {
                Sides = sides
            };

            var side = RollDice.Execute(parameters);

            await context.RespondAsync($"{context.Message.Author.Mention} you rolled **{side}**.");
        }
    }
}