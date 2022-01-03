using Newtonsoft.Json;

namespace DiscordBot.Api.Models.Dragonballs
{
    public class DragonballCharacterResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("assist")]
        public string Assist { get; set; } = default!;

        [JsonProperty("color")]
        public int Color { get; set; } = default;

    }
}
