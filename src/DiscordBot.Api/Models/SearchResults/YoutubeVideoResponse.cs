using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.SearchResults
{
    public class YoutubeVideoResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("link")]
        public string Link { get; set; } = default!;

        [JsonPropertyName("publishedAt")]
        public DateTime PublishedAt { get; set; }
    }
}
