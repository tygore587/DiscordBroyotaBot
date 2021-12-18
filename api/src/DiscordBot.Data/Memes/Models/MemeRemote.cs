using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscordBot.Data.Memes.Models
{
    [JsonObject]
    public record MemeRemote
    (
        [JsonProperty("postLink")] string PostLink,
        [JsonProperty("title")] string Title,
        [JsonProperty("url")] string Url,
        [JsonProperty("subreddit")] string? Subreddit,
        [JsonProperty("nsfw")] bool Nsfw,
        [JsonProperty("spoiler")] bool Spoiler,
        [JsonProperty("author")] string? Author,
        [JsonProperty("ups")] int Ups,
        [JsonProperty("preview")] List<string>? Preview
    );
}