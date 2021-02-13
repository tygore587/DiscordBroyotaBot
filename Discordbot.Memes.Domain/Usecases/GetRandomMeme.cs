using Discordbot.Core;
using Discordbot.Memes.Domain.Entities;
using Discordbot.Memes.Domain.Repositories;
using System.Threading.Tasks;

namespace Discordbot.Memes.Domain.Usecases
{
    public class GetRandomMeme : IUseCase<Task<Meme>, RandomMemeParameters>
    {
        private IMemesRepository MemesRepository { get; set; }

        public GetRandomMeme(IMemesRepository memesRepository)
        {
            MemesRepository = memesRepository;
        }

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
        public bool IncludeNSFW { get; set; }
    }
}