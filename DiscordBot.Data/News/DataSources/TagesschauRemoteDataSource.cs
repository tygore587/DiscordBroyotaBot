using System.Threading.Tasks;
using DiscordBot.Core.Xml;
using DiscordBot.Data.News.Models;
using DiscordBot.Data.Requests;

namespace DiscordBot.Data.News.DataSources
{
    internal class TagesschauRemoteDataSource : ITagesschauRemoteDataSource
    {
        private const string BaseUrl = "https://www.tagesschau.de/xml/rss2";

        private readonly IRequestClient _requestClient;

        public TagesschauRemoteDataSource(IRequestClient requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<RssRemote?> GetTagesschauNews()
        {
            var xml = await _requestClient.GetAsync<string>(BaseUrl);

            return XmlConvert.DeserializeObject<RssRemote>(xml);
        }
    }
}