using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.Memes
{
    public class MemeResponse
    {
        [JsonPropertyName("postLink")]
        public string PostLink { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("nsfw")]
        public bool Nsfw { get; set; }

    }
}
