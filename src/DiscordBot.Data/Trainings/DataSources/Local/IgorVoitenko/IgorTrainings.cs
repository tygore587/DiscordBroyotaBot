using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.IgorVoitenko
{
    public abstract class IgorTrainings
    {
        public static readonly TrainingLocal WarmUpRoutine = new("Warm Up Routine", "https://youtu.be/ZO2ZwicxCEs");

        public static readonly TrainingLocal CoolDownRoutine = new("Cool down Routine", "https://youtu.be/ZO2ZwicxCEs");

        public static readonly TrainingLocal ChestWorkout =
            new("6 MIN CHEST WORKOUT", "https://www.youtube.com/watch?v=G2XrGztOTi0");

        public static readonly TrainingLocal Days28 = new("Get 6 PACK ABS in 28 Days", "https://youtu.be/TIMghHu6QFU");

        public static readonly TrainingLocal FixPosture =
            new("FIX Rounded Posture in 8 min", "https://youtu.be/Z0G2fLP9Hl0");

        public static readonly TrainingLocal SixMinLegs =
            new("The PERFECT Home LEG Workout", "https://www.youtube.com/watch?v=vUf6sKEHKi0");

        public static readonly TrainingLocal SixPackAbs8Minutes =
            new("Perfect ABS Workout To Get 6 PACK", "https://youtu.be/JLdSuFF62AI");

        public static readonly TrainingLocal BackIn5Minutes =
            new("5 MIN PERFECT BACK Workout", "https://www.youtube.com/watch?v=SOvsUhLCdys");

        public static readonly TrainingLocal SixMinuteShoulders =
            new("6 MIN Quick SHOULDERS Workout At Home", "https://www.youtube.com/watch?v=tKU64bd4gaw");

        public static readonly TrainingLocal ChestShouldersAbsTriceps10Minutes =
            new("10 MIN FULL BODY FAT BURN HOME WORKOUT", "https://www.youtube.com/watch?v=oZjW1o1gorw");

        public static readonly TrainingLocal BigArms8Minutes =
            new("Build Big ARMS in 8 Minutes", "https://youtu.be/wwKb-wZCEjs");

        public static readonly TrainingLocal GetWiderIn28Days =
            new("How to Get WIDER in 28 Days", "https://www.youtube.com/watch?v=gdXLJiFfR6M");

        public static readonly TrainingLocal ObliqueUpperAbsLowerAbs =
            new("ABS Workout At Home For Men", "https://www.youtube.com/watch?v=vICVYyx22AY");
    }
}