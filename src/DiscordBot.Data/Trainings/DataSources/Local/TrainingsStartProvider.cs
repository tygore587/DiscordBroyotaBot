using System;

namespace DiscordBot.Data.Trainings.DataSources.Local
{
    public class TrainingsStartProvider : ITrainingsStartProvider
    {
        public DateTime GetIgor0To100TrainingsStart => new(2021, 05, 02);
    }
}