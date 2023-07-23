using DiscordBot.Core.Domain;
using DiscordBot.Domain.WatchTogether.Entities;
using DiscordBot.Domain.WatchTogether.Repositories;
using System.Threading.Tasks;

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