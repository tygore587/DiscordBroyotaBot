using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace DiscordBot.Data.Requests
{
    public class RequestClient : IRequestClient
    {
        public async Task<TResult> GetAsync<TResult>(string baseUrl, List<string>? paths = null,
            Dictionary<string, string>? queries = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl), "Base url must not be null or empty.");

            return typeof(TResult) == typeof(string)
                ? (TResult) (object) await BuildUrl(baseUrl, paths, queries).GetStringAsync(cancellationToken)
                : await BuildUrl(baseUrl, paths, queries).GetJsonAsync<TResult>(cancellationToken);
        }

        public async Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl,
            List<string>? paths = null, Dictionary<string, string>? queries = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl), "Base url must not be null.");


            return typeof(TResult) == typeof(string)
                ? (TResult) (object) await BuildUrl(baseUrl, paths, queries)
                    .PostJsonAsync(requestBody, cancellationToken).ReceiveString()
                : await BuildUrl(baseUrl, paths, queries).PostJsonAsync(requestBody, cancellationToken)
                    .ReceiveJson<TResult>();
        }

        private static string BuildUrl(string baseUrl, IReadOnlyCollection<string>? paths,
            Dictionary<string, string>? queries)
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