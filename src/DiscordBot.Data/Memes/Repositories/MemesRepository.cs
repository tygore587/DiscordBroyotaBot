using System;
using System.Threading.Tasks;
using DiscordBot.Data.Memes.DataSources;
using DiscordBot.Domain.Memes.Entities;
using DiscordBot.Domain.Memes.Repositories;
using Serilog;

namespace DiscordBot.Data.Memes.Repositories
{
    internal class MemesRepository : IMemesRepository
    {
        private readonly ILogger _logger;
        private readonly IMemesRemoteDataSource _remoteDataSource;

        public MemesRepository(IMemesRemoteDataSource remoteDataSource, ILogger logger)
        {
            _remoteDataSource = remoteDataSource;
            _logger = logger;
        }

        public async Task<Meme?> GetRandomMeme()
        {
            try
            {
                var randomMeme = await _remoteDataSource.GetRandomMeme();

                return randomMeme;
            }
            catch (Exception ex)
            {
                _logger.Error("Error while getting random meme. Exception: {@ex}", ex);
                return null;
            }
        }
    }
}