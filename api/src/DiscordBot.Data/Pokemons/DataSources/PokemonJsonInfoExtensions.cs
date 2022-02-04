using DiscordBot.Data.Pokemons.Models;
using DiscordBot.Domain.Pokemons.Entities;

namespace DiscordBot.Data.Pokemons.DataSources
{
    internal static class PokemonJsonInfoExtensions
    {
        public static PokemonBaseInfo ToEntity(this PokemonJsonInfo pokemonInfo)
        {
            return new PokemonBaseInfo(pokemonInfo.Id, pokemonInfo.EnglishName, pokemonInfo.GermanName);
        }
    }
}
