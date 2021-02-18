using Discordbot.Core;
using DiscordBot.WatchTogether.Domain.Entities;
using DiscordBot.WatchTogether.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace DiscordBot.WatchTogether.Domain.UseCases
{
    public class CreateWatchTogetherRoom : IUseCase<Task<CreatedRoom>, CreateWatchTogehterRoomParameters>
    {

        private IWatchTogetherRepository _watchTogetherRepository;

        public CreateWatchTogetherRoom(IWatchTogetherRepository watchTogetherRepository)
        {
            _watchTogetherRepository = watchTogetherRepository;
        }

        public Task<CreatedRoom> Execute(CreateWatchTogehterRoomParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters), "Parameters must not be null or empty.");

            return _watchTogetherRepository.CreateWatchTogetherRoom(parameters.YoutubeLink);
        }
    }

    public class CreateWatchTogehterRoomParameters
    {
        public string YoutubeLink { get; init; }
    }
}
