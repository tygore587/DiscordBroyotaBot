using DiscordBot.Core;
using DiscordBot.Domain.Pokemons.Entities;
using DiscordBot.Domain.Pokemons.Repositories;
using System.Collections.Generic;

namespace DiscordBot.Domain.Pokemons.UseCases
{
    public class FindPokemonByName : IUseCase<List<PokemonBaseInfo>, FindPokemonByNameParameter>
    {
        private readonly IPokemonRepository pokemonRepository;

        public FindPokemonByName(IPokemonRepository pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;
        }

        public List<PokemonBaseInfo> Execute(FindPokemonByNameParameter parameters)
        {
            return pokemonRepository.FindPokemonsByName(parameters.Name);
        }
    }

    public record FindPokemonByNameParameter(string Name);
}
