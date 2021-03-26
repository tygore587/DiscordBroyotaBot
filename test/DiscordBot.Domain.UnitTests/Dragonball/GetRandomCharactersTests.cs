using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Domain.Dragonball.Entities;
using DiscordBot.Domain.Dragonball.Repositories;
using DiscordBot.Domain.Dragonball.UseCases;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Domain.UnitTests.Dragonball
{
    public class GetRandomCharactersTests
    {
        private readonly IDragonballRepository _dragonballRepository;

        private readonly Random _random;

        private GetRandomCharacters _getRandomCharacters;

        public GetRandomCharactersTests()
        {
            _dragonballRepository = Substitute.For<IDragonballRepository>();
            _random = Substitute.For<Random>();

            _getRandomCharacters = new GetRandomCharacters(_random, _dragonballRepository);
        }

        [Fact]
        public void Execute_Should_Throw_Exception_With_Count_Smaller_Or_Equal_To_Zero()
        {
            var parameters = new RandomCharacterParams()
            {
                Count = 0,
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => _getRandomCharacters.Execute(parameters));
        }

        [Fact]
        public void Execute_Should_Return_Two_Different_Characters_With_Second_Choice_Is_The_Same_Name()
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

            var parameters = new RandomCharacterParams()
            {
                Count = expectedCount,
            };

            var actualCharacters = _getRandomCharacters.Execute(parameters);

            actualCharacters.Should().NotBeNullOrEmpty();
            actualCharacters.Should().HaveCount(2);
            actualCharacters.Should().Contain(character => existingCharacterNames.Contains(character.Name));
            
        }
    }
}