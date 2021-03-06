using System.Threading.Tasks;

namespace DiscordBot.Domain.News.Repositories
{
    public interface INewsRepository
    {
        Task<string> GetLatestTagesschauNews();
    }
}