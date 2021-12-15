using DiscordBot.Api.Common;
using DiscordBot.Api.Models.Dies;
using DiscordBot.Domain.Dies.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Dies
{
    [Route("dies")]
    public class DiesController : BaseController<DiesController>
    {
        private readonly RollDice rollDice;

        public DiesController(ILogger<DiesController> logger, RollDice rollDice) : base(logger)
        {
            this.rollDice = rollDice;
        }

        [HttpGet("roll/{sides}")]
        public IActionResult RollDies(int sides)
        {
            try
            {
                var param = new DieParameter { Sides = sides };

                var eyes = rollDice.Execute(param);

                return Ok(new RollResult { Eyes = eyes });

            }
            catch (Exception ex)
            {
                return HandleException(ex, "Error while rolling the dice.");
            }
        }
    }
}
