using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Data.DataSources.Local.News
{
    public interface INewsLocalCacheDataSource
    {
        Task<List<NewsInternal>?> Get(string newsPortal);
        Task Remove(string newsPortal);
        Task Set(string newsPortal, List<NewsInternal> newsInternal);
        bool TryGet(string newsPortal, out List<NewsInternal>? newsInternal);
    }
}