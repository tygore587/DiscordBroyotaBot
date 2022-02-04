using DiscordBot.Domain.Pokemons.Entities;
using System.Collections.Generic;

namespace DiscordBot.Data.Pokemons.DataSources
{
    public interface IPokemonLocalJsonDataSource
    {
        List<PokemonBaseInfo> FindPokemonsByName(string name);
        PokemonBaseInfo? GetPokemonById(string id);
    }
}
