using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Core.Domain;
using DiscordBot.Domain.Youtube.Entities;
using DiscordBot.Domain.Youtube.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Domain.Youtube.UseCases
{
    public class SearchNewestVideoFromChannel : IUseCase<Task<VideoSearchResult>, SearchNewestVideoParameter>
    {
        private readonly IYoutubeRepository _youtubeRepository;

        private readonly IDateTimeProvider _dateTimeProvider;

        public SearchNewestVideoFromChannel(IYoutubeRepository youtubeRepository, IDateTimeProvider dateTimeProvider)
        {
            _youtubeRepository = youtubeRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<VideoSearchResult> Execute(SearchNewestVideoParameter parameters)
        {
            var youtubeVideos = await _youtubeRepository.GetVideosFromChannel(parameters.ChannelId);

            var newestFoundVideo = youtubeVideos
                .Where(video => video.Title.Contains(parameters.SearchTerm, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(video => video.Published)
                .FirstOrDefault();

            var nowDate = _dateTimeProvider.UtcNow().Date;

            return new(newestFoundVideo, newestFoundVideo != null && newestFoundVideo.Published.Date == nowDate);
        }
    }

    public record SearchNewestVideoParameter(string ChannelId, string SearchTerm);
}
