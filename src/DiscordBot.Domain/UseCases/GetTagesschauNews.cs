using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Core;
using DiscordBot.Domain.Entities;
using DiscordBot.Domain.Repositories;

namespace DiscordBot.Domain.UseCases
{
    public class GetTagesschauNews : IUseCase<Task<List<NewsInternal>>, TagesschauParameters>
    {
        private readonly INewsRepository _newsRepository;

        public GetTagesschauNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<List<NewsInternal>> Execute(TagesschauParameters parameters)
        {
            if (parameters.Count <= 0)
                throw new ArgumentOutOfRangeException(nameof(parameters.Count), "Parameter counts must not be null.");

            var news = await _newsRepository.GetTagesschauNews();

            if (news is null)
                throw new ArgumentNullException(nameof(news), "News must not be null.");

            return news.Take(parameters.Count).ToList();
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