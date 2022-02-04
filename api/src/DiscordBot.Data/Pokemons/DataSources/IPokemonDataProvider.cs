using DiscordBot.Data.Pokemons.Models;
using DiscordBot.Domain.Pokemons.Entities;
using System.Collections.Generic;

namespace DiscordBot.Data.Pokemons.DataSources
{
    internal interface IPokemonDataProvider
    {
        IReadOnlyDictionary<string, PokemonBaseInfo> GetPokemonData();
    }
}