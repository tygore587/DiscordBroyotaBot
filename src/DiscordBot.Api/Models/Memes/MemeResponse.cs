using Newtonsoft.Json;

namespace DiscordBot.Api.Models.Memes
{
    [JsonObject]
    public class MemeResponse
    {
        [JsonProperty("postLink")]
        public string PostLink { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

    }
}
