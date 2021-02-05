using DiscordBot.Domain.Dragonball.Models;
using System;
using System.Linq;

namespace DiscordBot.Domain.Dragonball.Helper
{
    public static class DragonballCharacterHelper
    {
        public static DragonballCharacter GetDragonBallCharacter()
        {
            var random = new Random();
            var chosenCharacterIndex = random.Next(DragonballDefaults.CharacterNames.Count);
            var randomCharacter = DragonballDefaults.CharacterNames.ElementAt(chosenCharacterIndex);

            var randomAssistIndex = random.Next(DragonballDefaults.Assists.Count);
            var randomAssist = DragonballDefaults.Assists.ElementAt(randomAssistIndex);

            var randomColor = random.Next(DragonballDefaults.NumberOfColors);

            return new DragonballCharacter(randomCharacter, randomAssist, randomColor);
        }
    }
}