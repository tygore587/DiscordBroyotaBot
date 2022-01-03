using DiscordBot.Api.Common;
using DiscordBot.Api.Models;
using DiscordBot.Api.Models.Dragonballs;
using DiscordBot.Domain.Dragonball.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Dragonball
{
    [Route("dragonballs")]
    public class DragonballsController : BaseController<DragonballsController>
    {

        private readonly GetRandomCharacters getRandomCharacters;

        public DragonballsController(ILogger<DragonballsController> logger, GetRandomCharacters getRandomCharacters) : base(logger)
        {
            this.getRandomCharacters = getRandomCharacters;
        }

        [HttpGet("random")]
        [ProducesResponseType(typeof(List<DragonballCharacterResponse>), StatusCodes.Status200OK)]
        [Produces(MimeType.ApplicationJson)]
        public IActionResult GetRandomCharacters(int count = 3)
        {
            if (count <= 0)
            {
                logger.LogError("Error while getting random characters. Count was zero or lower than 3. Count: {count}", count);
                return Problem("Count was less or equal to 0.");
            }

            try
            {
                var parameters = new RandomCharacterParams
                {
                    Count = count,
                };

                var characters = getRandomCharacters.Execute(parameters);

                return Ok(characters.ToDragonballCharacterResponseList());
            }
            catch (Exception ex)
            {
                return HandleException(ex, "Error while getting random characters.", "Count: {count}", count);
            }
        }
    }
}
