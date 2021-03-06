using System.Threading.Tasks;
using DiscordBot.Core;
using DiscordBot.Domain.News.Repositories;

namespace DiscordBot.Domain.News.UseCases
{
    public class GetTagesschauNews : IUseCase<Task<string>, TagesschauParameters>
    {
        private readonly INewsRepository _newsRepository;

        public GetTagesschauNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<string> Execute(TagesschauParameters parameters)
        {
            return await _newsRepository.GetLatestTagesschauNews();
        }
    }

    public class TagesschauParameters
    {
        public TagesschauParameters(int count)
        {
            Count = count;
        }

        public int Count { get; }
    }
}