using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Data.News.DataSources.Local
{
    public interface INewsLocalCacheDataSource
    {
        Task<List<NewsEntity>?> Get(string newsPortal);
        Task Remove(string newsPortal);
        Task Set(string newsPortal, List<NewsEntity> newsInternal);
        bool TryGet(string newsPortal, out List<NewsEntity>? newsInternal);
    }
}