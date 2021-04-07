using System.Collections.Generic;

namespace DiscordBot.Data.Requests
{
    public interface IUrlBuilder
    {
        public string BuildUrl(string baseUrl, IReadOnlyCollection<string> paths,
            IReadOnlyCollection<KeyValuePair<string, string>> queries);
    }
}