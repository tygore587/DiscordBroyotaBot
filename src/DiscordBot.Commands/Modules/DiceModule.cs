using System.Threading.Tasks;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Dies.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable UnusedMember.Global

namespace DiscordBot.Commands.Modules
{
    [Description("All dices commands.")]
    public class DiceModule : BaseCommandModule
    {
        private readonly ICommandLogger _logger;
        private readonly RollDice _rollDice;

        public DiceModule(RollDice rollDice, ICommandLogger logger)
        {
            _rollDice = rollDice;
            _logger = logger;
        }

        [Command("roll")]
        [Description("This rolls a die with sides.")]
        [RequireGuild]
        public async Task RollDie(CommandContext context, [Description("Number of sides")] int sides = 20)
        {
            if (sides is <= 0 or > 100)
            {
                await context.RespondAsync(
                    $"{context.Message.Author.Mention} your die must have between 1 and 100 sides.");
                return;
            }

            var parameters = new DieParameter
            {
                Sides = sides
            };

            var side = _rollDice.Execute(parameters);

            _logger.Information(context, "Successfully processed dice roll command.");

            await context.RespondAsync($"{context.Message.Author.Mention} you rolled **{side}**. (d{sides})");
        }
    }
}