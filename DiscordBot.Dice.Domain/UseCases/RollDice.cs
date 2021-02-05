using System;
using System.Collections.Concurrent;
using Discordbot.Core;
using DiscordBot.Dice.Domain.Models;

namespace DiscordBot.Dice.Domain.UseCases
{
    public class RollDice : IUseCase<int, DieParameter>
    {
        private static ConcurrentDictionary<int, Die> Dies { get; } = new();

        public int Execute(DieParameter parameters)
        {
            if (Dies.TryGetValue(parameters.Sides, out var die))
                return die.Roll();

            var dice = new Die(parameters.Sides, new Random());

            Dies.TryAdd(parameters.Sides, dice);

            return dice.Roll();
        }
    }

    public class DieParameter
    {
        public int Sides { get; set; }
    }
}