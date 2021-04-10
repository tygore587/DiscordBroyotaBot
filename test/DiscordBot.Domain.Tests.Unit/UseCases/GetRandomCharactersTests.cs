using System;
using System.Linq;
using AutoFixture;
using DiscordBot.Domain.Repositories;
using DiscordBot.Domain.UseCases;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Domain.UnitTests.UseCases
{
    public class GetRandomCharactersTests
    {
        private readonly IDragonballRepository _dragonballRepository;

        private readonly GetRandomCharacters _getRandomCharacters;

        private readonly Random _random;

        public GetRandomCharactersTests()
        {
            _dragonballRepository = Substitute.For<IDragonballRepository>();
            _random = Substitute.For<Random>();

            _getRandomCharacters = new GetRandomCharacters(_random, _dragonballRepository);
        }

        [Fact]
        public void ShouldThrowExceptionWithCountSmallerOrEqualToZero()
        {
            var parameters = new RandomCharacterParams
            {
                Count = 0
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => _getRandomCharacters.Execute(parameters));
        }

        [Fact]
        public void ShouldReturnTwoDifferentCharactersWithSecondChoiceIsTheSameName()
        {
            _random.Next(default, default).ReturnsForAnyArgs(0, 0, 1);

            var fixture = new Fixture();

            // must be at least 2
            const int expectedCount = 2;

            var existingCharacterNames = fixture.CreateMany<string>(expectedCount).ToList();
            _dragonballRepository.GetDragonballCharacterNames().Returns(existingCharacterNames);
            _random.Next(existingCharacterNames.Count).Returns(0, 0, 1);

            var existingAssists = fixture.CreateMany<string>(expectedCount + 1).ToList();
            _dragonballRepository.GetAssists().ReturnsForAnyArgs(existingAssists);
            _random.Next(existingAssists.Count).Returns(0);

            const int existingNumberOfColors = expectedCount + 2;
            _random.Next(existingNumberOfColors).Returns(existingNumberOfColors);

            var parameters = new RandomCharacterParams
            {
                Count = expectedCount
            };

            var actualCharacters = _getRandomCharacters.Execute(parameters);

            actualCharacters.Should().NotBeNullOrEmpty();
            actualCharacters.Should().HaveCount(2);
            actualCharacters.Should().Contain(character => existingCharacterNames.Contains(character.Name));
        }
    }
}