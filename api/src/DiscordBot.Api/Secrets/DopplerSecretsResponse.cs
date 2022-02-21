using Newtonsoft.Json;

namespace DiscordBot.Api.Secrets
{
    public class DopplerSecretsResponse
    {
        [JsonProperty("FIREBASE_PROJECT_ID")]
        public string FirebaseProjectId { get; set; } = default!;

        [JsonProperty("WATCH_TOGETHER_API_KEY")]
        public string WatchTogetherApiKey { get; set; } = default!;
    }
}
