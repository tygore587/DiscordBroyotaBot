using DiscordBot.Api.Common;
using DiscordBot.Domain.WatchTogether.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.WatchTogether
{


    [Route("watchTogether")]
    public class WatchTogetherController : BaseController<WatchTogetherController>
    {

        private readonly CreateWatchTogetherRoom createWatchTogetherRoom;

        public WatchTogetherController(ILogger<WatchTogetherController> logger, CreateWatchTogetherRoom createWatchTogetherRoom) : base(logger)
        {
            this.createWatchTogetherRoom = createWatchTogetherRoom;
        }

        [HttpPost("room")]
        public async Task<IActionResult> CreateRoom(string? link)
        {
            try
            {
                var param = new CreateWatchTogetherRoomParameters(link);

                var createdRoom = await createWatchTogetherRoom.Execute(param);

                return Ok(createdRoom.ToSharedRoom());

            }
            catch (Exception ex)
            {
                return HandleException(ex, "Error while getting random meme.");
            }
        }
    }
}
