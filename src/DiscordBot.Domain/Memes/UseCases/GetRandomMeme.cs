﻿using System;
using System.Threading.Tasks;
using DiscordBot.Core;
using DiscordBot.Domain.Memes.Entities;
using DiscordBot.Domain.Memes.Repositories;

namespace DiscordBot.Domain.Memes.UseCases
{
    public class GetRandomMeme : IUseCase<Task<Meme>, RandomMemeParameters>
    {
        private readonly IMemesRepository _memesRepository;

        public GetRandomMeme(IMemesRepository memesRepository)
        {
            _memesRepository = memesRepository;
        }

        public async Task<Meme> Execute(RandomMemeParameters parameters)
        {
            var randomMeme = await _memesRepository.GetRandomMeme();

            if (randomMeme == null)
                throw new ArgumentNullException(nameof(randomMeme), "Couldn't get a random meme from repository.");

            while (randomMeme?.Nsfw == true && !parameters.IncludeNsfw)
                randomMeme = await _memesRepository.GetRandomMeme();

            return randomMeme!;
        }
    }

    public class RandomMemeParameters
    {
        public bool IncludeNsfw { get; init; }
    }
}