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
        public Task<TResult> GetAsync<TResult>(string baseUrl, CancellationToken cancellationToken = default)
        {
            return GetAsync<TResult>(baseUrl, null, null, cancellationToken);
        }

        public Task<TResult> GetAsync<TResult>(string baseUrl, List<string>? paths,
            CancellationToken cancellationToken = default)
        {
            return GetAsync<TResult>(baseUrl, paths, null, cancellationToken);
        }


        public async Task<TResult> GetAsync<TResult>(string baseUrl, List<string>? paths,
            IReadOnlyCollection<KeyValuePair<string, string>>? queries, CancellationToken cancellationToken = default)
        {
            return typeof(TResult) == typeof(string)
                ? (TResult) (object) await BuildUrl(baseUrl, paths, queries).GetStringAsync(cancellationToken)
                : await BuildUrl(baseUrl, paths, queries).GetJsonAsync<TResult>(cancellationToken);
        }

        public Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl,
            CancellationToken cancellationToken = default)
        {
            return PostJsonAsync<TRequest, TResult>(requestBody, baseUrl, null, cancellationToken);
        }


        public Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl,
            List<string>? paths,
            CancellationToken cancellationToken = default)
        {
            return PostJsonAsync<TRequest, TResult>(requestBody, baseUrl, paths, null, cancellationToken);
        }


        public async Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl,
            List<string>? paths, IReadOnlyCollection<KeyValuePair<string, string>>? queries,
            CancellationToken cancellationToken = default)
        {
            return typeof(TResult) == typeof(string)
                ? (TResult) (object) await BuildUrl(baseUrl, paths, queries)
                    .PostJsonAsync(requestBody, cancellationToken).ReceiveString()
                : await BuildUrl(baseUrl, paths, queries).PostJsonAsync(requestBody, cancellationToken)
                    .ReceiveJson<TResult>();
        }

        private static string BuildUrl(string baseUrl, IReadOnlyCollection<string>? paths,
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