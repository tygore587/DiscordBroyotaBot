#nullable enable
using System;
using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Domain.Memes.Entities;
using DiscordBot.Domain.Memes.Repositories;
using DiscordBot.Domain.Memes.UseCases;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Domain.UnitTests.Memes.UseCases
{
    public class GetRandomMemeTests
    {
        private readonly GetRandomMeme _getRandomMeme;
        private readonly IMemesRepository _memesRepository;

        public GetRandomMemeTests()
        {
            _memesRepository = Substitute.For<IMemesRepository>();
            _getRandomMeme = new GetRandomMeme(_memesRepository);
        }

        [Fact]
        public async Task Should_Return_Meme_Successfully()
        {
            var fixture = new Fixture();

            var expectedMeme = fixture.Build<Meme>().With(meme => meme.Nsfw, true).Create();

            _memesRepository.GetRandomMeme().Returns(expectedMeme);

            var parameters = fixture.Build<RandomMemeParameters>().With(meme => meme.IncludeNsfw, true).Create();

            var actualMeme = await _getRandomMeme.Execute(parameters);

            actualMeme.Should().NotBeNull();
            actualMeme.Should().BeEquivalentTo(expectedMeme);
        }

        [Fact]
        public async Task Should_Search_For_A_Meme_Until_Find_One_Without_NSFW_Tag()
        {
            var fixture = new Fixture();

            var memeWithNsfwContent = fixture.Build<Meme>().With(meme => meme.Nsfw, true).Create();

            var expectedReturnedMeme = fixture.Build<Meme>().With(meme => meme.Nsfw, false).Create();

            _memesRepository.GetRandomMeme().Returns(memeWithNsfwContent, expectedReturnedMeme);

            var parameters = fixture.Build<RandomMemeParameters>().With(meme => meme.IncludeNsfw, false).Create();

            var actualMeme = await _getRandomMeme.Execute(parameters);

            actualMeme.Should().NotBeNull();
            actualMeme.Should().BeEquivalentTo(expectedReturnedMeme);

            await _memesRepository.Received(2).GetRandomMeme();
        }

        [Fact]
        public async Task Should_Throw_Exception_If_No_Meme_Was_Returned()
        {
            var fixture = new Fixture();

            _memesRepository.GetRandomMeme().Returns(null as Meme);

            var parameters = fixture.Build<RandomMemeParameters>().With(meme => meme.IncludeNsfw, false).Create();

            await Assert.ThrowsAsync<ArgumentNullException>(() => _getRandomMeme.Execute(parameters));
        }
    }
}