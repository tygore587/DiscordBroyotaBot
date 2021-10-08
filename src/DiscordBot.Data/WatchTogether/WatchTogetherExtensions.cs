using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DiscordBot.Data.WatchTogether.Models;
using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Data.WatchTogether
{
    internal static class WatchTogetherExtensions
    {
        public static CreatedRoom ToCreatedRoom(this WatchTogetherRoomRemote watchTogetherRoomRemote)
        {
            if (string.IsNullOrWhiteSpace(watchTogetherRoomRemote.StreamKey))
                throw new ArgumentNullException(nameof(watchTogetherRoomRemote.StreamKey),
                    "Stream key is null or empty.");

            return new CreatedRoom(watchTogetherRoomRemote.StreamKey);
        }

        public static List<WatchTogetherRoomAddVideosUrlsRemote> ToWatchTogetherRoomAddVideosUrlsList(this IEnumerable<Video> videos)
        {
            return videos.Select(ToWatchTogetherRoomAddVideosUrls).ToList();
        }


        private static WatchTogetherRoomAddVideosUrlsRemote ToWatchTogetherRoomAddVideosUrls(this Video video)
        {
            return new WatchTogetherRoomAddVideosUrlsRemote(video.Url, video.Title, video.ThumbnailLink);
        }
    }
}