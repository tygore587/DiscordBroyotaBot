using System;
using System.Linq;
using System.Web;

namespace DiscordBot.Domain.Youtube
{
    public static class YoutubeHelper
    {
        private const string VideoIdQueryParameter = "v";

        private const string YoutubeShortStringStart = "youtu.be";

        public static string? GetVideoId(string youtubeLink)
        {
            string? videoId = null;
            var uri = new Uri(youtubeLink);

            if (youtubeLink.Contains(YoutubeShortStringStart))
            {
                var segments = uri.Segments;

                if (segments?.Length > 1)
                    videoId = segments[1];
            }
            else
            {
                var query = HttpUtility.ParseQueryString(uri.Query);
                videoId = query.Get(VideoIdQueryParameter); 
            }

            return videoId;
        }

        public static string? BuildVideoThumbnailLink(string youtubeLink)
        {
            var videoId = GetVideoId(youtubeLink);

            if (string.IsNullOrWhiteSpace(videoId))
                return null;

            return $"https://i.ytimg.com/vi/{videoId}/hqdefault.jpg";
        }
    }
}
