using DiscordBot.Data.Pokemons.Models;
using DiscordBot.Domain.Pokemons.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiscordBot.Data.Pokemons.DataSources
{
    internal class PokemonDataProvider : IPokemonDataProvider
    {
        private const string PokemonDataFileName = "pokemon_german_english_id.json";

        private readonly IReadOnlyDictionary<string, PokemonBaseInfo> PokemonById;

        public PokemonDataProvider()
        {
            var rootDir = System.Reflection.Assembly.GetExecutingAssembly();

            var json = File.ReadAllText(PokemonDataFileName);

            var pokemons = JsonConvert.DeserializeObject<List<PokemonJsonInfo>>(json);

            if (pokemons == null)
                throw new ArgumentNullException(nameof(pokemons), "Pokemons can't be null.");

            PokemonById = pokemons.ToDictionary(pokemons => pokemons.Id, pokemons => pokemons.ToEntity());
        }

        public IReadOnlyDictionary<string, PokemonBaseInfo> GetPokemonData()
        {
            return PokemonById;
        }
    }
}
