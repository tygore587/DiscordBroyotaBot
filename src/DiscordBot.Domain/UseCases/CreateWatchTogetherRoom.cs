using System.Threading.Tasks;
using DiscordBot.Core;
using DiscordBot.Domain.Entities;
using DiscordBot.Domain.Repositories;

namespace DiscordBot.Domain.UseCases
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