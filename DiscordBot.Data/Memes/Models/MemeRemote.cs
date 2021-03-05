using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscordBot.Data.Memes.Models
{
    [JsonObject]
    public class MemeRemote
    {
        [JsonProperty("postLink")]
        public string PostLink { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("spoiler")]
        public bool Spoiler { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("ups")]
        public int Ups { get; set; }

        [JsonProperty("preview")]
        public List<string> Preview { get; set; }
    }
}