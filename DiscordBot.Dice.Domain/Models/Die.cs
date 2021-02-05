using System;

namespace DiscordBot.Dice.Domain.Models
{
    public class Die
    {
        public Die(int sides, Random random)
        {
            Sides = sides;
            Random = random;
        }

        private int Sides { get; }

        private Random Random { get; }

        public int Roll()
        {
            return Random.Next(1, Sides + 1);
        }
    }
}