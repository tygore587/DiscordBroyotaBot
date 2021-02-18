using Discordbot.WatchTogether.Data.Models;
using DiscordBot.WatchTogether.Domain.Entities;

namespace Discordbot.WatchTogether.Data.Extensions
{
    internal static class CreatedRoomExtensions
    {
        public static CreatedRoom ToCreatedRoom(this CreatedRoomRemote createdRoomRemote)
        {
            return createdRoomRemote == null
                ? null
                : new CreatedRoom
                {
                    StreamKey = createdRoomRemote.Streamkey,
                };
        }
    }
}
