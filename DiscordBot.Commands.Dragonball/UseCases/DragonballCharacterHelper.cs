using DiscordBot.Commands.Dragonball.Models;
using DiscordBot.Core.Commands.Dragonball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Dragonball.UseCases
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
