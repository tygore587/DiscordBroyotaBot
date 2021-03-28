using System.Collections.Generic;
using System.Linq;
using Flurl;

namespace DiscordBot.Data.Requests
{
    public class UrlBuilder : IUrlBuilder
    {
        public string BuildUrl(string baseUrl, IReadOnlyCollection<string>? paths,
            IReadOnlyCollection<KeyValuePair<string, string>>? queries)
        {
            var resultUrl = baseUrl;

            if (paths?.Any() == true)
                resultUrl = resultUrl.AppendPathSegments(paths);

            if (queries?.Any() == true)
                resultUrl = resultUrl.SetQueryParams(queries);

            return resultUrl;
        }
    }
}