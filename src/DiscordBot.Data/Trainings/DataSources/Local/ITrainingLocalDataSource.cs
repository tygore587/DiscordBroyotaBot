﻿using System;
using DiscordBot.Domain.Trainings.Entities;

namespace DiscordBot.Data.Trainings.DataSources.Local
{
    public interface ITrainingLocalDataSource
    {
        TrainingsDay GetActualTraining(long day, TrainingType type);
        DateTime GetTrainingsStart(TrainingType type);
    }
}