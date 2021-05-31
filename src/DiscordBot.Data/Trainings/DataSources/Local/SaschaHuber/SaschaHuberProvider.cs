using System.Collections.Generic;
using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.SaschaHuber
{
    public class SaschaHuberProvider : ISaschaHuberProvider
    {
        public TrainingsPlanLocal Plan1Starter()
        {
            return new(
                "https://www.youtube.com/watch?v=wE6WbkhGQhI",
                new Dictionary<long, TrainingDayLocal>
                {
                    {
                        1, new TrainingDayLocal(SaschaTrainings.ThreeMinuteWarmup, new List<TrainingLocal>
                            {
                                SaschaTrainings.Chest, SaschaTrainings.Shoulders, SaschaTrainings.SixMinuteSixPack
                            }, new List<TrainingLocal> {SaschaTrainings.ShouldersNoWeights},
                            SaschaTrainings.ThreeMinuteWarmup)
                    },
                    {
                        2,
                        new TrainingDayLocal(SaschaTrainings.ThreeMinuteWarmup,
                            new List<TrainingLocal> {SaschaTrainings.Biceps, SaschaTrainings.Triceps},
                            SaschaTrainings.ThreeMinuteWarmup)
                    },
                    {
                        3,
                        new TrainingDayLocal(SaschaTrainings.ThreeMinuteWarmup,
                            new List<TrainingLocal>
                                {SaschaTrainings.Back1, SaschaTrainings.Legs1, SaschaTrainings.TenMinuteSixPack},
                            SaschaTrainings.ThreeMinuteWarmup)
                    },
                    {4, TrainingDayLocal.RestDay},
                    {
                        5,
                        new TrainingDayLocal(SaschaTrainings.ThreeMinuteWarmup,
                            new List<TrainingLocal> {SaschaTrainings.UpperBody}, SaschaTrainings.ThreeMinuteWarmup)
                    },
                    {
                        6,
                        new TrainingDayLocal(SaschaTrainings.ThreeMinuteWarmup,
                            new List<TrainingLocal>
                                {SaschaTrainings.Back2, SaschaTrainings.Legs2, SaschaTrainings.TenMinuteSixPack},
                            SaschaTrainings.ThreeMinuteWarmup)
                    },
                    {7, TrainingDayLocal.RestDay}
                }, "https://i.scdn.co/image/ab67706c0000bebb040e12f860ad6deebe22917f");
        }
    }
}