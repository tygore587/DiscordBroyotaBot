using System.Threading.Tasks;
using Discordbot.Core;
using DiscordBot.Domain.Memes.Entities;
using DiscordBot.Domain.Memes.Repositories;

namespace DiscordBot.Domain.Memes.UseCases
{
    public class GetRandomMeme : IUseCase<Task<Meme>, RandomMemeParameters>
    {
        public GetRandomMeme(IMemesRepository memesRepository)
        {
            MemesRepository = memesRepository;
        }

        private IMemesRepository MemesRepository { get; }

        public async Task<Meme> Execute(RandomMemeParameters parameters)
        {
            var randomMeme = await MemesRepository.GetRandomMeme();

            while (randomMeme?.Nsfw == true && !parameters.IncludeNSFW)
                randomMeme = await MemesRepository.GetRandomMeme();

            return randomMeme;
        }
    }

    public class RandomMemeParameters
    {
        public bool IncludeNSFW { get; init; }
    }
}