using DiscordBot.Data.WatchTogether.Models;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether.Extensions
{
    internal static class CreatedRoomExtensions
    {
        public static CreatedRoom ToCreatedRoom(this CreatedRoomRemote createdRoomRemote)
        {
            return new(createdRoomRemote.StreamKey);
        }
    }
}