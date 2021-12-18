using System.Collections.Generic;
using DiscordBot.Data.Dragonball.DataSources;
using DiscordBot.Data.Dragonball.DataSources.Provider;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Data.Tests.Unit.Dragonball.DataSources
{
    public class DragonballCharacterPropertiesLocalDataSourceTests
    {
        private readonly IDragonballCharacterPropertyProvider _characterPropertyProvider;

        private readonly DragonballCharacterPropertiesLocalDataSource _sut;

        public DragonballCharacterPropertiesLocalDataSourceTests()
        {
            _characterPropertyProvider = Substitute.For<IDragonballCharacterPropertyProvider>();
            _sut = new DragonballCharacterPropertiesLocalDataSource(_characterPropertyProvider);
        }

        [Fact]
        public void GetCharacterNamesShouldReturnCharacterNamesCorrectly()
        {
            var expectedCharactersNames = new List<string> {"test1"};
            _characterPropertyProvider.GetCharacterNames().Returns(expectedCharactersNames);

            var actualNames = _sut.GetCharacterNames();

            actualNames.Should().BeEquivalentTo(expectedCharactersNames);
        }

        [Fact]
        public void GetAssistsShouldReturnAssistVariantsCorrectly()
        {
            var expectedAssists = new List<string> {"test1"};
            _characterPropertyProvider.GetAssists().Returns(expectedAssists);

            var actualAssists = _sut.GetAssistVariants();

            actualAssists.Should().BeEquivalentTo(expectedAssists);
        }

        [Fact]
        public void GetColorVariantsCorrectly()
        {
            const int expectedColors = 3;
            _characterPropertyProvider.GetColorOptions().Returns(expectedColors);

            var actualColors = _sut.GetColorVariants();

            actualColors.Should().BeGreaterOrEqualTo(expectedColors);
        }
    }
}