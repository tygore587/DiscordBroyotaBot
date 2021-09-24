using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.WatchTogether.Models
{
    [JsonObject]
    public class WatchTogetherRoomAddVideosRemote
    {
        [JsonProperty("w2g_api_key")]
        public string WatchTogetherApiKey { get; }

        [JsonProperty("add_items")]
        public List<WatchTogetherRoomAddVideosUrls> VideosToAdd { get; }

        public WatchTogetherRoomAddVideosRemote(string watchTogetherApiKey, List<WatchTogetherRoomAddVideosUrls> videosToAdd)
        {
            WatchTogetherApiKey = watchTogetherApiKey;

            if (videosToAdd.Count > 50)
                throw new ArgumentOutOfRangeException(nameof(VideosToAdd), "You can only add up to 50 videos at once.");

            VideosToAdd = videosToAdd;
        }
    }
}
