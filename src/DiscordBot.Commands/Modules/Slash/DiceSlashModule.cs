using DisCatSharp.ApplicationCommands;
using DisCatSharp.ApplicationCommands.Attributes;
using DisCatSharp.ApplicationCommands.Context;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Dies.UseCases;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Modules.Slash
{
    public class DiceSlashModule : ApplicationCommandsModule
    {
        private readonly ICommandLogger _logger;
        private readonly RollDice _rollDice;

        public DiceSlashModule(ICommandLogger logger, RollDice rollDice)
        {
            _logger = logger;
            _rollDice = rollDice;
        }

        [SlashCommand("roll", "this rolls a die with sides.")]
        public async Task RollDie(InteractionContext ctx,
            [Option("sides", "number of sides between 2 and 1000. The default is 20.")]
            long sides = 20)
        {
            if (sides is <= 1 or > 1000)
            {
                await ctx.RespondWithError(
                    $"{ctx.Member.Mention} your die must have between 1 and 1000 sides.");
                return;
            }

            try
            {
                var parameters = new DieParameter
                {
                    Sides = (int) sides
                };

                var side = _rollDice.Execute(parameters);

                _logger.Information(ctx, "Successfully processed dice roll command.");

                await ctx.RespondImmediate($"{ctx.Member.Mention} you rolled **{side}**. (d{sides})");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ctx, "Error rolling the die. Sides: {Sides}", sides);
                await ctx.RespondWithError($"Error while rolling the die. {ex.Message}");
            }
        }
    }
}