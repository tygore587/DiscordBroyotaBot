using Discordbot.Core;
using DiscordBot.Dice.Domain.Models;

namespace DiscordBot.Dice.Domain.UseCases
{
    public class RollDice : IUseCase<int, DieParameter>
    {
        private readonly Die _die;

        public RollDice(Die die)
        {
            _die = die;
        }

        public int Execute(DieParameter parameters)
        {
            return _die.Roll(parameters.Sides);
        }
    }

    public class DieParameter
    {
        public int Sides { get; init; }
    }
}