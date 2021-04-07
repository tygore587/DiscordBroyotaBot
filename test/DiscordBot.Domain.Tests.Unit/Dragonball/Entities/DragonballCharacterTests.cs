using AutoFixture;
using DiscordBot.Domain.Dragonball.Entities;
using FluentAssertions;
using Xunit;

namespace DiscordBot.Domain.UnitTests.Dragonball.Entities
{
    public class DragonballCharacterTests
    {
        [Fact]
        public void ToString_ShouldReturnStringWithoutColor()
        {
            var fixture = new Fixture();
            var expectedName = fixture.Create<string>();
            var expectedAssist = fixture.Create<string>();
            var notExpectedColor = fixture.Create<int>();

            var character = new DragonballCharacter(expectedName, expectedAssist, notExpectedColor);

            var toString = character.ToString();

            toString.Should().NotBeNull();
            toString.Should().Contain(expectedName);
            toString.Should().Contain(expectedAssist);
            toString.Should().NotContain($"{notExpectedColor}");
        }

        [Fact]
        public void ToStringWithColor_ShouldReturnStringWithColor()
        {
            var fixture = new Fixture();
            var expectedName = fixture.Create<string>();
            var expectedAssist = fixture.Create<string>();
            var expectedColor = fixture.Create<int>();

            var character = new DragonballCharacter(expectedName, expectedAssist, expectedColor);

            var toString = character.ToStringWithColor();

            toString.Should().NotBeNull();
            toString.Should().Contain(expectedName);
            toString.Should().Contain(expectedAssist);
            toString.Should().Contain($"{expectedColor}");
        }
    }
}