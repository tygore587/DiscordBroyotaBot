using System;

namespace DiscordBot.Dice.Domain.Entities
{
    public class Die
    {
        public Die(Random random)
        {
            Random = random;
        }

        private Random Random { get; }


        public int Roll(int sides)
        {
            return Random.Next(1, sides + 1);
        }
    }
}