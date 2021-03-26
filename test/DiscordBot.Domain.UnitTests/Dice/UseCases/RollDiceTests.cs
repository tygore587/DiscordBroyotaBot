using System;
using AutoFixture;
using DiscordBot.Domain.Dice.UseCases;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Domain.UnitTests.Dice.UseCases
{
    public class RollDiceTests
    {
        private readonly Random _random;

        private readonly RollDice _rollDice;

        public RollDiceTests()
        {
            _random = Substitute.For<Random>();
            _rollDice = new RollDice(_random);
        }

        [Fact]
        public void Should_Roll_With_Correct_Number_Of_Sides()
        {
            var fixture = new Fixture();

            var expectedValue = fixture.Create<int>();
            const int sides = 40;
            const int expectedMaxValueNext = sides + 1;

            _random.Next(default, default).ReturnsForAnyArgs(expectedValue);

            var parameters = new DieParameter
            {
                Sides = sides,
            };

            var actualValue = _rollDice.Execute(parameters);

            actualValue.Should().Be(expectedValue);
            _random.Received().Next(1, expectedMaxValueNext);
        }

        [Fact]
        public void Should_Throw_Exception_With_Validation_Errors()
        {
            var parametersBelowZero = new DieParameter()
            {
                Sides = 0,
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => _rollDice.Execute(parametersBelowZero));

            var parametersAbove100 = new DieParameter()
            {
                Sides = 101,
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => _rollDice.Execute(parametersAbove100));
        }
    }
}