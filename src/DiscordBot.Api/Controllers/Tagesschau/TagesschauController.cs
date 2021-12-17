using System;
using DiscordBot.Api.Common;
using DiscordBot.Domain.Youtube.Entities;
using DiscordBot.Domain.Youtube.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Tagesschau
{
    [Route("tagesschau")]
    public class TagesschauController : BaseController<TagesschauController>
    {
        private readonly SearchNewestVideoFromChannel searchNewestVideoFromChannel;

        public TagesschauController(
            ILogger<TagesschauController> logger,
            SearchNewestVideoFromChannel searchNewestVideoFromChannel) : base(logger)
        {
            this.searchNewestVideoFromChannel = searchNewestVideoFromChannel;
        }

        [HttpGet("video/today")]
        public async Task<IActionResult> GetNewestVideo()
        {
            try
            {
                var parameter = new SearchNewestVideoParameter(YoutubeChannelIds.Tagesschau, "tagesschau 20");

                var videoResult = await searchNewestVideoFromChannel.Execute(parameter);

                if (videoResult == null)
                    return NotFound("No tagesschau video found.");



                var message =
                    videoResult.LatestFoundVideo == null
                        ? "No video was found."
                        : videoResult.FoundVideoFromToday
                            ? $"{videoResult.LatestFoundVideo.Link}"
                            : $"**No video for today was found.**\nLast video found: {videoResult.LatestFoundVideo.Link}";

                return Ok(randomMeme.ToMemeResponse());

            }
            catch (Exception ex)
            {
                return HandleException(ex, "Error while getting random meme.");
            }
        }
    }
}

