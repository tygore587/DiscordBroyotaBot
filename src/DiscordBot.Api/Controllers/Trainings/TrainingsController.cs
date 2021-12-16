using DiscordBot.Api.Common;
using DiscordBot.Api.Models.Trainings;
using DiscordBot.Domain.Trainings.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Trainings
{
    [Route("trainigs")]
    public class TrainingsController : BaseController<TrainingsController>
    {
        private readonly GetTodayTraining getTodayTraining;
        public TrainingsController(ILogger<TrainingsController> logger, GetTodayTraining getTodayTraining) : base(logger)
        {
            this.getTodayTraining = getTodayTraining;
        }

        [HttpGet("day")]
        public async Task<IActionResult> GetTodaysTrainng([FromQuery] int day = 0, [FromQuery] TrainingsPlan plan = TrainingsPlan.SaschaHuberPlan1Starter)
        {
            try
            {
                var param = new GetTodayTrainingParameter(day, plan.ToTraingsType());

                var training = await getTodayTraining.Execute(param);

                return Ok(training.ToTrainingResultResponse());

            }
            catch (Exception ex)
            {
                return HandleException(ex, "Error while getting random meme.");
            }
        }

    }
}
