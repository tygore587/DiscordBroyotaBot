using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Domain.Entities;
using DiscordBot.Domain.Repositories;
using DiscordBot.Domain.UseCases;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Domain.UnitTests.UseCases
{
    public class CreateWatchTogetherRoomTests
    {
        private readonly CreateWatchTogetherRoom _createWatchTogetherRoom;
        private readonly IWatchTogetherRepository _watchTogetherRepository;

        public CreateWatchTogetherRoomTests()
        {
            _watchTogetherRepository = Substitute.For<IWatchTogetherRepository>();
            _createWatchTogetherRoom = new CreateWatchTogetherRoom(_watchTogetherRepository);
        }

        [Fact]
        public async Task ShouldCreateAWatchTogetherRoomSuccessfully()
        {
            var fixture = new Fixture();

            var expectedRoom = fixture.Create<CreatedRoom>();

            _watchTogetherRepository.CreateWatchTogetherRoom(Arg.Any<string>()).Returns(expectedRoom);

            var parameters = fixture.Create<CreateWatchTogetherRoomParameters>();

            var actualRoom = await _createWatchTogetherRoom.Execute(parameters);

            actualRoom.Should().NotBeNull();
            actualRoom.Should().BeEquivalentTo(expectedRoom);
        }
    }
}