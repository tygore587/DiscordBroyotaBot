using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot.Core.Data.Requests
{
    public interface IRequestClient
    {
        Task<TResult> GetJsonAsync<TResult>(string baseUrl, CancellationToken cancellationToken = default);
        Task<TResult> GetJsonAsync<TResult>(string baseUrl, List<string> paths, CancellationToken cancellationToken = default);
        Task<TResult> GetJsonAsync<TResult>(string baseUrl, List<string> paths, Dictionary<string, string> queries, CancellationToken cancellationToken = default);
    }
}
