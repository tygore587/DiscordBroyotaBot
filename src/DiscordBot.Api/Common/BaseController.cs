using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Common
{
    [ApiController]
    public abstract class BaseController<T> : ControllerBase 
    {
        protected readonly ILogger<T> logger;

        protected BaseController(ILogger<T> logger)
        {
            this.logger = logger;
        }

        protected IActionResult HandleException(Exception ex, string errorMessage, params object[]? parameter)
        {
            logger.LogError(errorMessage, ex, parameter);

            return BadRequest(errorMessage);
        }
    }
}
