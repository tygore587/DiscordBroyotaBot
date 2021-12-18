namespace DiscordBot.Domain.Trainings.Entities
{
    public record TrainingsPlanDay
    (
        string TrainingsUrl,
        TrainingsDay TrainingsDay,
        string? ImageUrl = null
    );
}