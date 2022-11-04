using Newtonsoft.Json;

namespace DiscordBot.Api.Secrets
{
    public class DopplerSecretsResponse
    {
        [JsonProperty("API_KEY")]
        public string ApiKey {get; set;} = default!;

        [JsonProperty("WATCH_TOGETHER_API_KEY")]
        public string WatchTogetherApiKey { get; set; } = default!;
    }
}
