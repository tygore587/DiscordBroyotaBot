using System;
using System.Threading.Tasks;
using DiscordBot.Data.Memes.DataSources;
using DiscordBot.Data.Memes.Extensions;
using DiscordBot.Domain.Memes.Entities;
using DiscordBot.Domain.Memes.Repositories;

namespace DiscordBot.Data.Memes.Repositories
{
    internal class MemesRepository : IMemesRepository
    {
        private readonly IMemesRemoteDataSource RemoteDataSource;

        public MemesRepository(IMemesRemoteDataSource remoteDataSource)
        {
            RemoteDataSource = remoteDataSource;
        }

        public async Task<Meme> GetRandomMeme()
        {
            try
            {
                var randomMeme = await RemoteDataSource.GetRandomMeme();

                return randomMeme.ToMeme();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}