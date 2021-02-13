using Discordbot.Memes.Domain.Entities;
using Discordbot.Memes.Domain.Repositories;
using DiscordBot.Memes.Data.DataSources;
using DiscordBot.Memes.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Memes.Data.Repositories
{
    public class MemesRepository : IMemesRepository
    {
        private IMemesRemoteDataSource RemoteDataSource;

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
