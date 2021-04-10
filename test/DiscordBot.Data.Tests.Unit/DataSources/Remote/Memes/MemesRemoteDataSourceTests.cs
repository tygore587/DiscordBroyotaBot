using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Data.DataSources.Remote.Memes;
using DiscordBot.Data.Extensions;
using DiscordBot.Data.Models.Remote;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace DiscordBot.Data.Tests.Unit.DataSources.Remote.Memes
{
    public class MemeRemoteDataSourceTests
    {
        private readonly IMemeApi _iMemeApi;

        private readonly MemesRemoteDataSource _sut;

        public MemeRemoteDataSourceTests()
        {
            _iMemeApi = Substitute.For<IMemeApi>();

            _sut = new MemesRemoteDataSource(_iMemeApi);
        }

        [Fact]
        public async Task GetRandomMemeShouldReturnMemeSuccessfully()
        {
            var fixture = new Fixture();

            var memeRemote = fixture.Create<MemeRemote>();

            _iMemeApi.GetRandomMeme(Arg.Any<CancellationToken>()).Returns(Task.FromResult(memeRemote));

            var expectedMeme = memeRemote.ToMeme();

            var actualMeme = await _sut.GetRandomMeme();

            actualMeme.Should().BeEquivalentTo(expectedMeme);
        }

        [Fact]
        public async Task GetRandomMemeShouldThrowExceptionIfRequestClientThrowsException()
        {
            _iMemeApi.GetRandomMeme(Arg.Any<CancellationToken>()).Throws(new Exception("testMessage"));

            await Assert.ThrowsAsync<Exception>(() => _sut.GetRandomMeme());
        }
    }
}