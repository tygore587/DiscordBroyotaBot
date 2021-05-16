using System.Collections.Generic;
using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.IgorVoitenko
{
    public interface IIgorVoitenkoProvider
    {
        Dictionary<long, TrainingDayLocal> From0To100Trainings();
    }
}