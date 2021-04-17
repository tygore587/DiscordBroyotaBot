using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Data.Memes;
using DiscordBot.Data.Memes.DataSources;
using DiscordBot.Domain.Memes.Entities;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Serilog;
using Xunit;

namespace DiscordBot.Data.Tests.Unit.Memes
{
    public class MemesRepositoryTests
    {
        private readonly ILogger _logger;

        private readonly IMemesRemoteDataSource _remoteDataSource;
        private readonly MemesRepository _sut;

        public MemesRepositoryTests()
        {
            _logger = Substitute.For<ILogger>();
            _remoteDataSource = Substitute.For<IMemesRemoteDataSource>();
            _sut = new MemesRepository(_remoteDataSource, _logger);
        }

        [Fact]
        public async Task GetRandomMemeReturnsMemeFromApiSuccessfully()
        {
            var fixture = new Fixture();

            var expectedMeme = fixture.Create<Meme>();

            _remoteDataSource.GetRandomMeme(Arg.Any<CancellationToken>()).Returns(Task.FromResult(expectedMeme));

            var actualMeme = await _sut.GetRandomMeme();

            actualMeme.Should().BeEquivalentTo(expectedMeme);
        }

        [Fact]
        public async Task GetRandomMemeReturnsNullIfExceptionIsThrownFromApi()
        {
            _remoteDataSource.GetRandomMeme(Arg.Any<CancellationToken>()).Throws(new Exception());

            var result = await _sut.GetRandomMeme();

            result.Should().BeNull();
        }
    }
}