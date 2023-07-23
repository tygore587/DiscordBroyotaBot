using DiscordBot.Core.Domain;
using DiscordBot.Domain.WatchTogether.Entities;
using DiscordBot.Domain.WatchTogether.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Domain.WatchTogether.UseCases
{
    public class AddVideosToWatchTogetherRoom : IUseCase<Task, AddVideosToWatchTogetherRoomParameter>
    {
        private readonly IWatchTogetherRepository watchTogetherRepository;

        public AddVideosToWatchTogetherRoom(IWatchTogetherRepository watchTogetherRepository)
        {
            this.watchTogetherRepository = watchTogetherRepository;
        }

        public async Task Execute(AddVideosToWatchTogetherRoomParameter parameters)
        {
            await watchTogetherRepository.AddVideosToRoom(parameters.RoomId, parameters.Videos);
        }
    }

    public record AddVideosToWatchTogetherRoomParameter(string RoomId, List<Video> Videos);
}
