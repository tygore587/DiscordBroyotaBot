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

            var parameters = fixture.Create<RandomMemeParameters>();

            var actualMeme = await _getRandomMeme.Execute(parameters);

            actualMeme.Should().NotBeNull();
            actualMeme.Should().BeEquivalentTo(expectedMeme);
        }
    }
}