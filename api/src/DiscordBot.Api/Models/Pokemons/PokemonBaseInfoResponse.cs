using Newtonsoft.Json;

namespace DiscordBot.Api.Models.Pokemons
{
    public class PokemonBaseInfoResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("englishName")]
        public string EnglishName { get; set; } = default!;

        [JsonProperty("germanName")]
        public string GermanName { get; set; } = default!;
    }
}
