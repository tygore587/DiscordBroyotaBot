using Flurl;
using Flurl.Http;
using Flurl.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot.Core.Data.Requests
{
    public class RequestClient : IRequestClient
    {
        public Task<TResult> GetJsonAsync<TResult>(string baseUrl, CancellationToken cancellationToken = default)
        {
            return GetJsonAsync<TResult>(baseUrl, new(), new(), cancellationToken);
        }

        public Task<TResult> GetJsonAsync<TResult>(string baseUrl, List<string> paths, CancellationToken cancellationToken = default)
        {
            return GetJsonAsync<TResult>(baseUrl, paths, new(), cancellationToken);
        }

        public Task<TResult> GetJsonAsync<TResult>(string baseUrl, List<string> paths, Dictionary<string, string> queries, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl), "Base url must not be null or empty.");

            var resultUrl = baseUrl;

            if (paths?.Any() == true)
                resultUrl = resultUrl.AppendPathSegments(paths);

            if (queries?.Any() == true)
                resultUrl = resultUrl.SetQueryParams(queries);

            return resultUrl.GetJsonAsync<TResult>(cancellationToken);
        }
    }
}