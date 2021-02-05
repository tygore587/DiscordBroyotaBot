using Discordbot.Core;
using DiscordBot.Dice.Domain.Models;

namespace DiscordBot.Dice.Domain.UseCases
{
    public class RollDice : IUseCase<int, DieParameter>
    {
        public RollDice(Die die)
        {
            Die ??= die;
        }

        private static Die Die { get; set; }

        public int Execute(DieParameter parameters)
        {
            return Die.Roll(parameters.Sides);
        }
    }

    public class DieParameter
    {
        public int Sides { get; set; }
    }
}