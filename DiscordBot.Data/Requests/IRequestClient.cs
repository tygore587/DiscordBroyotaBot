using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot.Data.Requests
{
    public interface IRequestClient
    {
        Task<TResult> GetAsync<TResult>(string baseUrl, List<string>? paths = null,
            IReadOnlyCollection<KeyValuePair<string, string>>? queries = null, CancellationToken cancellationToken = default);

        Task<TResult> PostJsonAsync<TRequest, TResult>(TRequest requestBody, string baseUrl, List<string>? paths = null,
            IReadOnlyCollection<KeyValuePair<string, string>>? queries = null, CancellationToken cancellationToken = default);
    }
}