using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.News.Models;
using Refit;

namespace DiscordBot.Data.News.DataSources.Remote.Tagesschau
{
    public interface ITagesschauApi
    {
        const string BaseUrl = "https://www.tagesschau.de";

        [Get("/xml/rss2")]
        public Task<RssRemote> GetTagesschauNews(CancellationToken cancellationToken);
    }
}