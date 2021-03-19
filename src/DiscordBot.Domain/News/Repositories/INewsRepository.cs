using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Domain.News.Repositories
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsInternal>?> GetTagesschauNews();
    }
}