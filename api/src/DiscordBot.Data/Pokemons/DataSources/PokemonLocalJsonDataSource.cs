using DiscordBot.Data.Pokemons.Models;
using DiscordBot.Domain.Pokemons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordBot.Data.Pokemons.DataSources
{
    internal class PokemonLocalJsonDataSource : IPokemonLocalJsonDataSource
    {

        private readonly IPokemonDataProvider pokemonDataProvider;

        public PokemonLocalJsonDataSource(IPokemonDataProvider pokemonDataProvider)
        {
            this.pokemonDataProvider = pokemonDataProvider;
        }

        public PokemonBaseInfo? GetPokemonById(string id)
        {
            var data = GetPokemonData();

            return data.GetValueOrDefault(id);
        }

        public List<PokemonBaseInfo> FindPokemonsByName(string name)
        {
            var data = GetPokemonData();

            return data
                .Where(pokemonEntry => pokemonEntry.Value.EnglishName?.Contains(name,StringComparison.OrdinalIgnoreCase) == true 
                        || pokemonEntry.Value.GermanName?.Contains(name,StringComparison.OrdinalIgnoreCase) == true)
                .Select(entry => entry.Value)
                .ToList();
        }

        private IReadOnlyDictionary<string, PokemonBaseInfo> GetPokemonData()
        {
            return pokemonDataProvider.GetPokemonData();
        }
    }
}
