using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Data.News.DataSources.Local
{
    public interface INewsLocalCacheDataSource
    {
        Task<List<NewsInternal>?> Get(string newsPortal);
        Task Remove(string newsPortal);
        Task Set(string newsPortal, List<NewsInternal> newsInternal);
        bool TryGet(string newsPortal, out List<NewsInternal>? newsInternal);
    }
}