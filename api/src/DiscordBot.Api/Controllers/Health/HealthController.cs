using System;
using DiscordBot.Api.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Health
{
    [AllowAnonymous]
    [Route("/")]
    [Route("/health")]
    public class HealthController : BaseController<HealthController>
    {
        public HealthController(ILogger<HealthController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new { status = "UP" });
        }
    }
}
