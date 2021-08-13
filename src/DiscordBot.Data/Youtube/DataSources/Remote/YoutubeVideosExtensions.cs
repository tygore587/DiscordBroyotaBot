using DiscordBot.Data.Youtube.Models;
using DiscordBot.Domain.Youtube.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Youtube.DataSources.Remote
{
    internal static class YoutubeVideosExtensions
    {
        public static YoutubeVideo ToYoutubeVideo(this YoutubeVideoInfoRemote videoInfoRemote)
        {
            return new YoutubeVideo(
                Title: videoInfoRemote.Title,
                Published: videoInfoRemote.Published,
                Link: videoInfoRemote?.LinkInfo?.Link ?? string.Empty
                );
        }

        public static List<YoutubeVideo> ToYoutubeVideos(this IEnumerable<YoutubeVideoInfoRemote> youtubeInfoRemotes)
        {
            return youtubeInfoRemotes.Select(ToYoutubeVideo).ToList();
        }

        public static IEnumerable<YoutubeVideoInfoRemote> WithoutEmptyLinkVideos(this IEnumerable<YoutubeVideoInfoRemote> videoInfos)
        {
            return videoInfos.Where(video => !string.IsNullOrWhiteSpace(video.LinkInfo?.Link));
        }
    }
}
