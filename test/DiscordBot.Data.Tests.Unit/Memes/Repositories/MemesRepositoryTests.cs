using DiscordBot.Data.Memes.DataSources;
using NSubstitute;
using Serilog;

namespace DiscordBot.Data.Tests.Unit.Memes.Repositories
{
    public class MemesRepositoryTests
    {
        private readonly ILogger _logger;

        private readonly IMemesRemoteDataSource _remoteDataSource;
        //private readonly MemeRepository 

        public MemesRepositoryTests()
        {
            _logger = Substitute.For<ILogger>();
            _remoteDataSource = Substitute.For<IMemesRemoteDataSource>();
        }
    }
}