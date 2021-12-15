using DiscordBot.Api.Common;
using DiscordBot.Domain.Memes.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Memes
{
    [Route("memes")]
    public class MemesController : BaseController<MemesController>
    {
        private readonly GetRandomMeme getRandomMeme;

        public MemesController(ILogger<MemesController> logger, GetRandomMeme getRandomMeme) : base(logger)
        {
            this.getRandomMeme = getRandomMeme;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomMeme([FromQuery] bool includeNSFW)
        {
            try
            {
                var param = new RandomMemeParameters { IncludeNsfw = includeNSFW };

                var randomMeme = await getRandomMeme.Execute(param);

                return Ok(randomMeme.ToMemeResponse());

            }
            catch (Exception ex)
            {
                return HandleException(ex, "Error while getting random meme.");
            }
        }
    }
}
