using DiscordBot.Data.Pokemons.DataSources;
using DiscordBot.Domain.Pokemons.Entities;
using DiscordBot.Domain.Pokemons.Repositories;
using System.Collections.Generic;

namespace DiscordBot.Data.Pokemons.Repositories
{
    internal class PokemonRepository : IPokemonRepository
    {
        private readonly IPokemonLocalJsonDataSource pokemonLocalJsonDataSource;

        public PokemonRepository(IPokemonLocalJsonDataSource pokemonLocalJsonDataSource)
        {
            this.pokemonLocalJsonDataSource = pokemonLocalJsonDataSource;
        }

        public List<PokemonBaseInfo> FindPokemonsByName(string name)
        {
            return pokemonLocalJsonDataSource.FindPokemonsByName(name);
        }
    }
}
