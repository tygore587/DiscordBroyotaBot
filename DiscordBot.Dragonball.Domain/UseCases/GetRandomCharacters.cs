using System;
using System.Collections.Generic;
using System.Linq;
using Discordbot.Core;
using DiscordBot.Dragonball.Domain.Helper;
using DiscordBot.Dragonball.Domain.Models;

namespace DiscordBot.Dragonball.Domain.UseCases
{
    public class GetRandomCharacters : IUseCase<List<DragonballCharacter>, NoParameters>
    {
        public List<DragonballCharacter> Execute(NoParameters parameters)
        {
            var characters = new List<DragonballCharacter>();

            while (characters.Count != 3)
            {
                var newCharacter = DragonballCharacterHelper.GetDragonBallCharacter();
                if (!characters.Any(character =>
                    string.Equals(character.Name, newCharacter.Name, StringComparison.OrdinalIgnoreCase)))
                    characters.Add(newCharacter);
            }

            return characters;
        }
    }
}