using System;
using System.Collections.Generic;
using System.Linq;
using DiscordBot.Core;
using Discordbot.Domain.Dragonball.Entities;
using DiscordBot.Domain.Dragonball.Repositories;

namespace DiscordBot.Domain.Dragonball.UseCases
{
    public class GetRandomCharacters : IUseCase<List<DragonballCharacter>, RandomCharacterParams>
    {
        private readonly IDragonballRepository _dragonballRepository;
        private readonly Random _random;

        public GetRandomCharacters(Random random, IDragonballRepository dragonballRepository)
        {
            _random = random;
            _dragonballRepository = dragonballRepository;
        }

        public List<DragonballCharacter> Execute(RandomCharacterParams parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters), "Parameters must not be null.");

            if (parameters.Count <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(parameters.Count)} must be bigger than 0.",
                    nameof(parameters.Count));

            var (characterNames, assists, colors) = GetCharacterProperties();

            var characters = new List<DragonballCharacter>();

            while (characters.Count != parameters.Count)
            {
                var newCharacter = ChooseRandomCharacter(characterNames, assists, colors);
                if (!characters.Any(character =>
                    string.Equals(character.Name, newCharacter.Name, StringComparison.OrdinalIgnoreCase)))
                    characters.Add(newCharacter);
            }

            return characters;
        }

        private (List<string> characterNames, List<string> assists, int colors) GetCharacterProperties()
        {
            return (_dragonballRepository.GetDragonballCharacterNames(),
                _dragonballRepository.GetAssists(),
                _dragonballRepository.GetColorVariants());
        }


        private DragonballCharacter ChooseRandomCharacter(IReadOnlyCollection<string> characterNames,
            IReadOnlyCollection<string> assists, int colors)
        {
            var chosenCharacterIndex = _random.Next(characterNames.Count);
            var randomCharacter = characterNames.ElementAt(chosenCharacterIndex);

            var randomAssistIndex = _random.Next(assists.Count);
            var randomAssist = assists.ElementAt(randomAssistIndex);

            var randomColor = _random.Next(colors);

            return new DragonballCharacter(randomCharacter, randomAssist, randomColor);
        }
    }

    public class RandomCharacterParams
    {
        public int Count { get; init; }
    }
}