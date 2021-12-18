using System.Text.Json.Serialization;

namespace DiscordBot.Api.Models.SearchResults
{
    public class TagesschauYoutubeSearchResponse
    {
        [JsonPropertyName("fromToday")]
        public bool FromToday { get; set; }

        [JsonPropertyName("video")]
        public YoutubeVideoResponse? Video { get; set; }
    }
}
