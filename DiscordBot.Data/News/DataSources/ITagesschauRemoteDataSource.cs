using System.Threading.Tasks;

namespace DiscordBot.Data.News.DataSources
{
    internal interface ITagesschauRemoteDataSource
    {
        Task<string> GetTagesschauNews();
    }
}