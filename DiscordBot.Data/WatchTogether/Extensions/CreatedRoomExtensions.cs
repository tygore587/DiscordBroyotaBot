using System;
using DiscordBot.Data.WatchTogether.Models;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether.Extensions
{
    internal static class CreatedRoomExtensions
    {
        public static CreatedRoom ToCreatedRoom(this CreatedRoomRemote createdRoomRemote)
        {
            if (string.IsNullOrWhiteSpace(createdRoomRemote.StreamKey))
                throw new ArgumentNullException(nameof(createdRoomRemote.StreamKey), "Stream key is null or empty.");

            return new CreatedRoom(createdRoomRemote.StreamKey!);
        }
    }
}