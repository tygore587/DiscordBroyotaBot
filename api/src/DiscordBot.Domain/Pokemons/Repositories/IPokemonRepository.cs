using DiscordBot.Domain.Pokemons.Entities;
using System.Collections.Generic;

namespace DiscordBot.Domain.Pokemons.Repositories
{
    public interface IPokemonRepository
    {
        List<PokemonBaseInfo> FindPokemonsByName(string name);
    }
}
