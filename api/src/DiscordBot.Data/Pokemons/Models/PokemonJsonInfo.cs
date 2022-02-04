using Newtonsoft.Json;

namespace DiscordBot.Data.Pokemons.Models
{
    [JsonObject]
    internal class PokemonJsonInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("german")]
        public string GermanName { get; set; } = default!;

        [JsonProperty("english")]
        public string EnglishName { get; set; } = default!;
    }
}
