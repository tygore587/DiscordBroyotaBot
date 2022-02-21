using DiscordBot.Core.Secrets;
using Newtonsoft.Json;
using System.Net;

namespace DiscordBot.Api.Secrets
{
    public static class DopplerSecretClient
    {
        public static async Task<ApplicationSecrets?> FetchSecrets(string token)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.doppler.com/v3/");
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");

            var response = await client.GetAsync("configs/config/secrets/download?format=json");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var dopplerSecrets = JsonConvert.DeserializeObject<DopplerSecretsResponse>(result);

            return dopplerSecrets == null 
                ? null
                : new ApplicationSecrets(dopplerSecrets.FirebaseProjectId, dopplerSecrets.WatchTogetherApiKey);
        }
    }
}
