using System;

namespace DiscordBot.Data.Trainings.DataSources.Local
{
    public interface ITrainingsStartProvider
    {
        DateTime GetIgor0To100TrainingsStart { get; }

        DateTime GetSaschaHuberPlan1StarterStart { get; }
    }
}