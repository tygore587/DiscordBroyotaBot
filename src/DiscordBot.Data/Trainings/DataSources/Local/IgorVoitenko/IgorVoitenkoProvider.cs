using System.Collections.Generic;
using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.IgorVoitenko
{
    public class IgorVoitenkoProvider : IIgorVoitenkoProvider
    {
        public TrainingsPlanLocal From0To100Trainings()
        {
            return new(
                "http://igorvoitenko.com/from0to100", new Dictionary<long, TrainingDayLocal>
                {
                    {
                        1, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.ChestWorkout,
                                IgorTrainings.Days28
                            },
                            new List<TrainingLocal> {IgorTrainings.FixPosture},
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        2, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.SixMinLegs,
                                IgorTrainings.SixPackAbs8Minutes
                            },
                            IgorTrainings.CoolDownRoutine
                        )
                    },
                    {3, TrainingDayLocal.RestDay},
                    {
                        4, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.BackIn5Minutes,
                                IgorTrainings.SixPackAbs8Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        5, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.WarmUpRoutine,
                                IgorTrainings.SixMinuteShoulders,
                                IgorTrainings.Days28,
                                IgorTrainings.WarmUpRoutine
                            },
                            new List<TrainingLocal> {IgorTrainings.FixPosture},
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        6, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.ChestShouldersAbsTriceps10Minutes,
                                IgorTrainings.BigArms8Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {7, TrainingDayLocal.RestDay},
                    {
                        8, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.GetWiderIn28Days,
                                IgorTrainings.BackIn5Minutes
                            },
                            new List<TrainingLocal> {IgorTrainings.FixPosture},
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        9, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.SixMinLegs,
                                IgorTrainings.SixPackAbs8Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {10, TrainingDayLocal.RestDay},
                    {
                        11, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.SixMinuteShoulders,
                                IgorTrainings.BackIn5Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        12, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal> {IgorTrainings.ChestShouldersAbsTriceps10Minutes},
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        13,
                        new TrainingDayLocal(IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal> {IgorTrainings.SixPackAbs8Minutes}, IgorTrainings.CoolDownRoutine)
                    },
                    {
                        14, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.SixMinLegs,
                                IgorTrainings.SixPackAbs8Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        15, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.BigArms8Minutes,
                                IgorTrainings.BackIn5Minutes,
                                IgorTrainings.ObliqueUpperAbsLowerAbs
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        16, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.GetWiderIn28Days,
                                IgorTrainings.ObliqueUpperAbsLowerAbs
                            },
                            new List<TrainingLocal> {IgorTrainings.FixPosture},
                            IgorTrainings.CoolDownRoutine)
                    },
                    {17, TrainingDayLocal.RestDay},
                    {
                        18, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal> {IgorTrainings.ChestShouldersAbsTriceps10Minutes},
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        19, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.ChestWorkout,
                                IgorTrainings.BackIn5Minutes,
                                IgorTrainings.ObliqueUpperAbsLowerAbs
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {20, TrainingDayLocal.RestDay},
                    {
                        21, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.SixMinLegs,
                                IgorTrainings.ThreeMinutePause,
                                IgorTrainings.SixMinLegs,
                                IgorTrainings.BigArms8Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        22, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.ChestShouldersAbsTriceps10Minutes,
                                IgorTrainings.Days28
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        23, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.ChestWorkout,
                                IgorTrainings.ThreeMinutePause,
                                IgorTrainings.ChestWorkout,
                                IgorTrainings.BackIn5Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        24,
                        new TrainingDayLocal(IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal> {IgorTrainings.SixPackAbs8Minutes}, IgorTrainings.CoolDownRoutine)
                    },
                    {
                        25, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.SixMinuteShoulders,
                                IgorTrainings.ThreeMinutePause,
                                IgorTrainings.SixMinuteShoulders,
                                IgorTrainings.SixMinLegs
                            },
                            new List<TrainingLocal> {IgorTrainings.FixPosture},
                            IgorTrainings.CoolDownRoutine)
                    },
                    {26, TrainingDayLocal.RestDay},
                    {
                        27, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.SixMinLegs,
                                IgorTrainings.Days28,
                                IgorTrainings.ThreeMinutePause,
                                IgorTrainings.Days28
                            },
                            IgorTrainings.CoolDownRoutine)
                    },
                    {
                        28, new TrainingDayLocal(
                            IgorTrainings.WarmUpRoutine,
                            new List<TrainingLocal>
                            {
                                IgorTrainings.GetWiderIn28Days,
                                IgorTrainings.ThreeMinutePause,
                                IgorTrainings.GetWiderIn28Days,
                                IgorTrainings.BackIn5Minutes,
                                IgorTrainings.BigArms8Minutes
                            },
                            IgorTrainings.CoolDownRoutine)
                    }
                },
                "https://thumb.tildacdn.com/tild3463-3938-4433-a666-643537343731/-/resize/400x/-/format/webp/from_0_100.jpg");
        }
    }
}