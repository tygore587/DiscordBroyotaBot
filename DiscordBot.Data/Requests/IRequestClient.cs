using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot.Data.Requests
{
    public interface IRequestClient
    {
        Task<TResult> GetAsync<TResult>(
            string baseUrl,
            CancellationToken cancellationToken = default);

        Task<TResult> GetAsync<TResult>(
            string baseUrl,
            IReadOnlyCollection<string> paths,
            CancellationToken cancellationToken = default);

        Task<TResult> GetAsync<TResult>(
            string baseUrl,
            IReadOnlyCollection<string> paths,
            IReadOnlyCollection<KeyValuePair<string, string>> queries,
            CancellationToken cancellationToken = default);

        Task<TResult> PostJsonAsync<TRequest, TResult>(
            TRequest requestBody,
            string baseUrl,
            CancellationToken cancellationToken = default);

        Task<TResult> PostJsonAsync<TRequest, TResult>(
            TRequest requestBody,
            string baseUrl,
            IReadOnlyCollection<string> paths,
            CancellationToken cancellationToken = default);

        Task<TResult> PostJsonAsync<TRequest, TResult>(
            TRequest requestBody,
            string baseUrl,
            IReadOnlyCollection<string> paths,
            IReadOnlyCollection<KeyValuePair<string, string>> queries,
            CancellationToken cancellationToken = default);
    }
}