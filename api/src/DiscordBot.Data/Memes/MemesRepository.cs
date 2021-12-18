using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiscordBot.Data;
using DiscordBot.Data.Memes.DataSources;
using DiscordBot.Domain.Memes.Entities;
using DiscordBot.Domain.Memes.Repositories;
using Serilog;

[assembly: InternalsVisibleTo(TestConstants.AssemblyName)]

namespace DiscordBot.Data.Memes
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
                return await _remoteDataSource.GetRandomMeme();
            }
            catch (Exception ex)
            {
                _logger.Error("Error while getting random meme. Exception: {@ex}", ex);
                return null;
            }
        }
    }
}