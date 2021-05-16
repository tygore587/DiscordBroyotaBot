using System;
using DiscordBot.Data.WatchTogether.Models;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether
{
    internal static class CreatedRoomExtensions
    {
        public static CreatedRoom ToCreatedRoom(this WatchTogetherRoomRemote watchTogetherRoomRemote, string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(watchTogetherRoomRemote.StreamKey))
                throw new ArgumentNullException(nameof(watchTogetherRoomRemote.StreamKey),
                    "Stream key is null or empty.");

            return new CreatedRoom($"{baseUrl}/{watchTogetherRoomRemote.StreamKey}");
        }
    }
}