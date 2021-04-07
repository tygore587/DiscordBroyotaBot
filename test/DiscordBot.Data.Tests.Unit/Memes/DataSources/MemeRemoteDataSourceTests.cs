using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Data.Memes.DataSources;
using DiscordBot.Data.Memes.Extensions;
using DiscordBot.Data.Memes.Models;
using DiscordBot.Data.Requests;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace DiscordBot.Data.Tests.Unit.Memes.DataSources
{
    public class MemeRemoteDataSourceTests
    {
        private readonly IRequestClient _requestClient;

        private readonly MemesRemoteDataSource _sut;

        public MemeRemoteDataSourceTests()
        {
            _requestClient = Substitute.For<IRequestClient>();

            _sut = new MemesRemoteDataSource(_requestClient);
        }

        [Fact]
        public async Task GetRandomMemeShouldReturnMemeSuccessfully()
        {
            var fixture = new Fixture();

            var memeRemote = fixture.Create<MemeRemote>();

            _requestClient.GetAsync<MemeRemote>(Arg.Any<string>(), Arg.Any<IReadOnlyCollection<string>>(),
                Arg.Any<CancellationToken>()).Returns(Task.FromResult(memeRemote));

            var expectedMeme = memeRemote.ToMeme();

            var actualMeme = await _sut.GetRandomMeme();

            actualMeme.Should().BeEquivalentTo(expectedMeme);
        }

        [Fact]
        public async Task GetRandomMemeShouldThrowExceptionIfRequestClientThrowsException()
        {
            _requestClient.GetAsync<MemeRemote>(Arg.Any<string>(), Arg.Any<IReadOnlyCollection<string>>(),
                Arg.Any<CancellationToken>()).Throws(new Exception("testMessage"));

            await Assert.ThrowsAsync<Exception>(() => _sut.GetRandomMeme());
        }
    }
}