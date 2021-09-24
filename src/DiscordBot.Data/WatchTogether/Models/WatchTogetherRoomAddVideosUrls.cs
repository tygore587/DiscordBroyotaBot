using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.WatchTogether.Models
{
    [JsonObject]
    public class WatchTogetherRoomAddVideosUrls
    {
        [JsonProperty("url")]
        public string Url {  get; }

        public WatchTogetherRoomAddVideosUrls(string url)
        {
            Url = url;
        }
    }
}
