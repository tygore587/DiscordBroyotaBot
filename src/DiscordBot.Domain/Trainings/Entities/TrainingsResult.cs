using DiscordBot.Domain.WatchTogether.Entities;

namespace DiscordBot.Domain.Trainings.Entities
{
    public record TrainingsResult(long Day, TrainingsDay TrainingsDay, CreatedRoom? WatchTogetherRoom);
}