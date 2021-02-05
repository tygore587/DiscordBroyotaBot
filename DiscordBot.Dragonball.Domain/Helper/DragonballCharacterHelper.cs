using System;
using System.Linq;
using DiscordBot.Dragonball.Domain.Models;

namespace DiscordBot.Dragonball.Domain.Helper
{
    public class DragonballCharacterHelper
    {
        public DragonballCharacterHelper(Random random)
        {
            Random = random;
        }

        private Random Random { get; }

        public DragonballCharacter GetDragonBallCharacter()
        {
            var chosenCharacterIndex = Random.Next(DragonballDefaults.CharacterNames.Count);
            var randomCharacter = DragonballDefaults.CharacterNames.ElementAt(chosenCharacterIndex);

            var randomAssistIndex = Random.Next(DragonballDefaults.Assists.Count);
            var randomAssist = DragonballDefaults.Assists.ElementAt(randomAssistIndex);

            var randomColor = Random.Next(DragonballDefaults.NumberOfColors);

            return new DragonballCharacter(randomCharacter, randomAssist, randomColor);
        }
    }
}