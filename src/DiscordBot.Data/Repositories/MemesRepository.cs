using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiscordBot.Data;
using DiscordBot.Data.DataSources.Remote.Memes;
using DiscordBot.Domain.Entities;
using DiscordBot.Domain.Repositories;
using Serilog;

[assembly: InternalsVisibleTo(TestConstants.AssemblyName)]

namespace DiscordBot.Data.Repositories
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