using System.Threading;
using System.Threading.Tasks;
using DiscordBot.Data.News.Models;
using Refit;

namespace DiscordBot.Data.News.DataSources
{
    public interface ITagesschauApi
    {
        public static readonly string BaseUrl = "https://www.tagesschau.de/xml/rss2";

        [Get("/")]
        public Task<RssRemote> GetTagesschauNews(CancellationToken cancellationToken);
    }
}