using System;
using System.Net.Mime;
using DiscordBot.Api.Common;
using DiscordBot.Api.Models;
using DiscordBot.Api.Models.SearchResults;
using DiscordBot.Domain.Youtube.Entities;
using DiscordBot.Domain.Youtube.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Tagesschau
{
    [Authorize]
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
        [Produces(MimeType.ApplicationJson)]
        [ProducesResponseType(typeof(TagesschauYoutubeSearchResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNewestVideo()
        {
            try
            {
                var parameter = new SearchNewestVideoParameter(YoutubeChannelIds.Tagesschau, "tagesschau 20");

                var videoResult = await searchNewestVideoFromChannel.Execute(parameter);

                if (videoResult == null)
                    return NotFound("No tagesschau video found.");

                return Ok(videoResult.ToTagesschauYoutubeSearchResponse());

            }
            catch (Exception ex)
            {
                return HandleException(ex, "Error while getting todays tagesschau video.");
            }
        }
    }
}

