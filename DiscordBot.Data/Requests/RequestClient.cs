using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;

namespace DiscordBot.Data.Requests
{
    public class RequestClient : IRequestClient
    {
        private readonly IUrlBuilder _urlBuilder;

        public RequestClient(IUrlBuilder urlBuilder)
        {
            _urlBuilder = urlBuilder;
        }

        public Task<TResult> GetAsync<TResult>(string baseUrl, CancellationToken cancellationToken = default)
        {
            return GetAsync<TResult>(baseUrl, Array.Empty<string>(), Array.Empty<KeyValuePair<string, string>>(),
                cancellationToken);
        }

        public Task<TResult> GetAsync<TResult>(string baseUrl, IReadOnlyCollection<string> paths,
            CancellationToken cancellationToken = default)
        {
            return GetAsync<TResult>(baseUrl, paths, Array.Empty<KeyValuePair<string, string>>(), cancellationToken);
        }


        public async Task<TResult> GetAsync<TResult>(string baseUrl, IReadOnlyCollection<string> paths,
            IReadOnlyCollection<KeyValuePair<string, string>> queries, CancellationToken cancellationToken = default)
        {
            var url = _urlBuilder.BuildUrl(baseUrl, paths, queries);

            return IsResultTypeString<TResult>()
                ? (TResult) (object) await url.GetStringAsync(cancellationToken)
                : await url.GetJsonAsync<TResult>(cancellationToken);
        }

        public Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl,
            CancellationToken cancellationToken = default)
        {
            return PostJsonAsync<TRequest, TResult>(requestBody, baseUrl, Array.Empty<string>(), cancellationToken);
        }


        public Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl,
            IReadOnlyCollection<string> paths,
            CancellationToken cancellationToken = default)
        {
            return PostJsonAsync<TRequest, TResult>(requestBody, baseUrl, paths,
                Array.Empty<KeyValuePair<string, string>>(), cancellationToken);
        }


        public async Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl,
            IReadOnlyCollection<string> paths, IReadOnlyCollection<KeyValuePair<string, string>> queries,
            CancellationToken cancellationToken = default)
        {
            var url = _urlBuilder.BuildUrl(baseUrl, paths, queries);

            return IsResultTypeString<TResult>()
                ? (TResult) (object) await url.PostJsonAsync(requestBody, cancellationToken).ReceiveString()
                : await url.PostJsonAsync(requestBody, cancellationToken).ReceiveJson<TResult>();
        }

        private static bool IsResultTypeString<TResult>()
        {
            return typeof(TResult) == typeof(string);
        }
    }
}