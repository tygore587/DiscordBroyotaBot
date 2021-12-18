using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.SaschaHuber
{
    public interface ISaschaHuberProvider
    {
        TrainingsPlanLocal Plan1Starter();
    }
}