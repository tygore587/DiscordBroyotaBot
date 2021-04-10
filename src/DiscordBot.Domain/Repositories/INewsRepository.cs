using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Domain.Repositories
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsInternal>?> GetTagesschauNews();
    }
}