using System;
using System.Collections.Generic;
using System.Linq;
using Discordbot.Core;
using DiscordBot.Dragonball.Domain.Entities;

namespace DiscordBot.Dragonball.Domain.UseCases
{
    public class GetRandomCharacters : IUseCase<List<DragonballCharacter>, RandomCharacterParams>
    {
        private readonly Random Random;

        public GetRandomCharacters(Random random)
        {
            Random = random;
        }

        public List<DragonballCharacter> Execute(RandomCharacterParams parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters), "Parameters must not be null.");

            if (parameters.Count <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(parameters.Count)} must be bigger than 0.", nameof(parameters.Count));

            var characters = new List<DragonballCharacter>();

            while (characters.Count != parameters.Count)
            {
                var newCharacter = GetDragonBallCharacter();
                if (!characters.Any(character =>
                    string.Equals(character.Name, newCharacter.Name, StringComparison.OrdinalIgnoreCase)))
                    characters.Add(newCharacter);
            }

            return characters;
        }

        private DragonballCharacter GetDragonBallCharacter()
        {
            var chosenCharacterIndex = Random.Next(DragonballDefaults.CharacterNames.Count);
            var randomCharacter = DragonballDefaults.CharacterNames.ElementAt(chosenCharacterIndex);

            var randomAssistIndex = Random.Next(DragonballDefaults.Assists.Count);
            var randomAssist = DragonballDefaults.Assists.ElementAt(randomAssistIndex);

            var randomColor = Random.Next(DragonballDefaults.NumberOfColors);

            return new DragonballCharacter(randomCharacter, randomAssist, randomColor);
        }
    }

    public class RandomCharacterParams
    {
        public int Count { get; init; }
    }
}