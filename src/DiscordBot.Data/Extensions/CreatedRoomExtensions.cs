using System;
using DiscordBot.Data.Models.Remote.WatchTogether;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Data.Extensions
{
    internal static class CreatedRoomExtensions
    {
        public static CreatedRoom ToCreatedRoom(this WatchTogetherRoomRemote watchTogetherRoomRemote)
        {
            if (string.IsNullOrWhiteSpace(watchTogetherRoomRemote.StreamKey))
                throw new ArgumentNullException(nameof(watchTogetherRoomRemote.StreamKey),
                    "Stream key is null or empty.");

            return new CreatedRoom(watchTogetherRoomRemote.StreamKey!);
        }
    }
}