using System.Collections.Generic;
using DiscordBot.Data.Dragonball;
using DiscordBot.Data.Dragonball.DataSources;
using DiscordBot.Domain.Dragonball.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Data.Tests.Unit.Dragonball
{
    public class DragonballRepositoryTests
    {
        private readonly IDragonballCharacterPropertiesLocalDataSource _dragonballCharacterPropertiesLocalDataSource;

        private readonly IDragonballRepository _sut;

        public DragonballRepositoryTests()
        {
            _dragonballCharacterPropertiesLocalDataSource =
                Substitute.For<IDragonballCharacterPropertiesLocalDataSource>();

            _sut = new DragonballRepository(_dragonballCharacterPropertiesLocalDataSource);
        }

        [Fact]
        public void GetCharacterNamesReturnCharacterNamesCorrectly()
        {
            var expectedCharactersNames = new List<string> {"test1"};
            _dragonballCharacterPropertiesLocalDataSource.GetCharacterNames().Returns(expectedCharactersNames);

            var actualNames = _sut.GetDragonballCharacterNames();

            actualNames.Should().BeEquivalentTo(expectedCharactersNames);
        }

        [Fact]
        public void GetAssistsReturnsAssistVariantsCorrectly()
        {
            var expectedAssists = new List<string> {"test1"};
            _dragonballCharacterPropertiesLocalDataSource.GetAssistVariants().Returns(expectedAssists);

            var actualAssists = _sut.GetAssists();

            actualAssists.Should().BeEquivalentTo(expectedAssists);
        }

        [Fact]
        public void GetColorVariantsReturnsColorsCorrectly()
        {
            const int expectedColors = 3;
            _dragonballCharacterPropertiesLocalDataSource.GetColorVariants().Returns(expectedColors);

            var actualColors = _sut.GetColorVariants();

            actualColors.Should().BeGreaterOrEqualTo(expectedColors);
        }
    }
}