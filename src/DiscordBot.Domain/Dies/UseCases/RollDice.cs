using System;
using DiscordBot.Core;

namespace DiscordBot.Domain.Dies.UseCases
{
    public class RollDice : IUseCase<int, DieParameter>
    {
        private readonly Random _random;

        public RollDice(Random random)
        {
            _random = random;
        }

        public int Execute(DieParameter parameters)
        {
            if (parameters.Sides <= 0 || parameters.Sides > 100)
                throw new ArgumentOutOfRangeException(nameof(parameters),
                    "Sides must be bigger than 0 and smaller or equal to 100."
                );

            return _random.Next(1, parameters.Sides + 1);
        }
    }

    public class DieParameter
    {
        public int Sides { get; init; }
    }
}