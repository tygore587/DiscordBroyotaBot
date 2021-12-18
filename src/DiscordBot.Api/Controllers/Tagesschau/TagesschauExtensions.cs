using DiscordBot.Api.Models.SearchResults;
using DiscordBot.Domain.Youtube.Entities;

namespace DiscordBot.Api.Controllers.Tagesschau
{
    public static class TagesschauExtensions
	{
		public static TagesschauYoutubeSearchResponse ToTagesschauYoutubeSearchResponse(this VideoSearchResult videoSearchResult)
        {
			return new TagesschauYoutubeSearchResponse
			{
				FromToday = videoSearchResult.FoundVideoFromToday,
				Video = videoSearchResult.LatestFoundVideo?.ToYoutubeVideoResponse(),
			};
        }

		private static YoutubeVideoResponse ToYoutubeVideoResponse(this YoutubeVideo video)
        {
			return new YoutubeVideoResponse
			{
				Link = video.Link,
				PublishedAt = video.Published,
				Title = video.Title,
			};
        }
	}
}

