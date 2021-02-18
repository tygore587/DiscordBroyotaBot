using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discordbot.WatchTogether.Data.Models
{
    [JsonObject]
    internal class RoomCreationRemote
    {
        [JsonProperty("w2g_api_key")]
        [JsonRequired]
        public string WatchTogetherApiKey { get; set; }

        [JsonProperty("share")]
        public string Share { get; set; }

        [JsonProperty("bg_color")]
        public string BackgroundColor { get; set; }

        [JsonProperty("bg_opacity")]
        public string BackgroundOpacity { get; set; }
    }
}
