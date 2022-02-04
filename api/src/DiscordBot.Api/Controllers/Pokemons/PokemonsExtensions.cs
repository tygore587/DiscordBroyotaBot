using DiscordBot.Api.Models.Pokemons;
using DiscordBot.Domain.Pokemons.Entities;

namespace DiscordBot.Api.Controllers.Pokemons
{
    public static class PokemonsExtensions
    {
        public static List<PokemonBaseInfoResponse> ToResponses(this IEnumerable<PokemonBaseInfo> pokemons)
        {
            return pokemons.Select(ToResponse).ToList();
        }

        public static PokemonBaseInfoResponse ToResponse(this PokemonBaseInfo pokemon)
        {
            return new PokemonBaseInfoResponse
            {
                EnglishName = pokemon.EnglishName,
                GermanName = pokemon.GermanName,
                Id = pokemon.Id,
            };
        }
    }
}
