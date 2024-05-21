using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiscordBot.Domain.Trainings.Entities
{
    public record TrainingsPlanDay
    (
        string TrainingsUrl,
        TrainingsDay TrainingsDay,
        string? ImageUrl = null
    )
    {
        public string? YoutubePlaylistUrl => GetYoutubePlaylist();

        private string? GetYoutubePlaylist()
        {
            var youtubeVideoIds = new List<string>();

            if (TryGetYoutubeVideoId(TrainingsDay.WarmUpTraining?.Link, out var warmupVideoId))
                youtubeVideoIds.Add(warmupVideoId);

            youtubeVideoIds.AddRange(GetYoutubeVideoIdsFromTrainings(TrainingsDay.MandatoryTrainings));

            if (TryGetYoutubeVideoId(TrainingsDay.CoolDownTraining?.Link, out var cooldownVideoId))
                youtubeVideoIds.Add(cooldownVideoId);

            youtubeVideoIds.AddRange(GetYoutubeVideoIdsFromTrainings(TrainingsDay.OptionsTrainings));

            return youtubeVideoIds.Any()
                ? $"http://www.youtube.com/watch_videos?video_ids={string.Join(",", youtubeVideoIds)}"
                : null;
        }


        private static bool TryGetYoutubeVideoId(string? link, out string videoId)
        {
            videoId = string.Empty;

            if (string.IsNullOrWhiteSpace(link))
                return false;

            if (!Uri.TryCreate(link, UriKind.RelativeOrAbsolute, out var url))
                return false;

            videoId = GetVideoIdFromUrl(url) ?? string.Empty;

            return !string.IsNullOrWhiteSpace(videoId);
        }

        private static string? GetVideoIdFromUrl(Uri url)
        {
            return url.Host switch
            {
                _ when url.Host.Contains("youtube.com", StringComparison.OrdinalIgnoreCase) => HttpUtility.ParseQueryString(url.Query)["v"],
                _ when url.Host.Contains("youtu.be", StringComparison.OrdinalIgnoreCase) => url.Segments.LastOrDefault(),
                _ => null
            };
        }

        private static List<string> GetYoutubeVideoIdsFromTrainings(List<Training> trainings)
        {
            return trainings
             .Select(training =>
             {
                 TryGetYoutubeVideoId(training.Link, out var trainingVideoId);

                 return trainingVideoId;
             })
             .Where(url => !string.IsNullOrWhiteSpace(url))
             .ToList();
        }
    };
}