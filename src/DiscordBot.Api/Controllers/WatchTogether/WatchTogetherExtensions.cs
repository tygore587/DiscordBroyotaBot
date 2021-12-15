using DiscordBot.Api.Models.WatchTogether;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Api.Controllers.WatchTogether
{
    public static class WatchTogetherExtensions
    {

        public static SharedRoom ToSharedRoom(this CreatedRoom room)
        {
            return new SharedRoom
            {
                Link = room.RoomLink,
            };
        }
    }
}
