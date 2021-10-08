using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.WatchTogether.Models
{
    [JsonObject]
    public class WatchTogetherRoomAddVideosUrlsRemote
    {
        [JsonProperty("url")]
        public string Url {  get; }

        [JsonProperty("title")]
        public string? Title { get; }

        [JsonProperty("thumb")]
        public string? ThumbnailLink { get; }

        public WatchTogetherRoomAddVideosUrlsRemote(string url, string? title, string? thumbnailLink)
        {
            Url = url;
            Title = title;
            ThumbnailLink = thumbnailLink;
        }
    }
}
