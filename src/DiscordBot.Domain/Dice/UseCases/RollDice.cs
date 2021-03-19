using DiscordBot.Core;
using DiscordBot.Domain.Dice.Entities;

namespace DiscordBot.Domain.Dice.UseCases
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