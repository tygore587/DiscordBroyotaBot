using System.Threading.Tasks;
using DiscordBot.Core;
using DiscordBot.Domain.WatchTogether.Entities;
using DiscordBot.Domain.WatchTogether.Repositories;

namespace DiscordBot.Domain.WatchTogether.UseCases
{
    public class CreateWatchTogetherRoom : IUseCase<Task<CreatedRoom>, CreateWatchTogetherRoomParameters>
    {
        private readonly IWatchTogetherRepository _watchTogetherRepository;

        public CreateWatchTogetherRoom(IWatchTogetherRepository watchTogetherRepository)
        {
            _watchTogetherRepository = watchTogetherRepository;
        }

        public Task<CreatedRoom> Execute(CreateWatchTogetherRoomParameters parameters)
        {
            return _watchTogetherRepository.CreateWatchTogetherRoom(parameters.YoutubeLink);
        }
    }

    public class CreateWatchTogetherRoomParameters
    {
        public CreateWatchTogetherRoomParameters(string? youtubeLink)
        {
            YoutubeLink = youtubeLink;
        }

        public string? YoutubeLink { get; }
    }
}