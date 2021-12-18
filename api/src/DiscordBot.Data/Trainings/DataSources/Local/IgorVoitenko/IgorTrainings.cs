using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.IgorVoitenko
{
    public abstract class IgorTrainings
    {
        public static readonly MandatoryTrainingLocal WarmUpRoutine = new("Warm Up Routine", "https://youtu.be/ZO2ZwicxCEs");

        public static readonly MandatoryTrainingLocal CoolDownRoutine = new("Cool down Routine", "https://youtu.be/ZO2ZwicxCEs");

        public static readonly MandatoryTrainingLocal ChestWorkout =
            new("6 MIN CHEST WORKOUT", "https://www.youtube.com/watch?v=G2XrGztOTi0");

        public static readonly MandatoryTrainingLocal Days28 = new("Get 6 PACK ABS in 28 Days", "https://youtu.be/TIMghHu6QFU");

        public static readonly OptionalTrainingLocal FixPosture =
            new("FIX Rounded Posture in 8 min", "https://youtu.be/Z0G2fLP9Hl0");

        public static readonly MandatoryTrainingLocal SixMinLegs =
            new("The PERFECT Home LEG Workout", "https://www.youtube.com/watch?v=vUf6sKEHKi0");

        public static readonly MandatoryTrainingLocal SixPackAbs8Minutes =
            new("Perfect ABS Workout To Get 6 PACK", "https://youtu.be/JLdSuFF62AI");

        public static readonly MandatoryTrainingLocal BackIn5Minutes =
            new("5 MIN PERFECT BACK Workout", "https://www.youtube.com/watch?v=SOvsUhLCdys");

        public static readonly MandatoryTrainingLocal SixMinuteShoulders =
            new("6 MIN Quick SHOULDERS Workout At Home", "https://www.youtube.com/watch?v=tKU64bd4gaw");

        public static readonly MandatoryTrainingLocal ChestShouldersAbsTriceps10Minutes =
            new("10 MIN FULL BODY FAT BURN HOME WORKOUT", "https://www.youtube.com/watch?v=oZjW1o1gorw");

        public static readonly MandatoryTrainingLocal BigArms8Minutes =
            new("Build Big ARMS in 8 Minutes", "https://youtu.be/wwKb-wZCEjs");

        public static readonly MandatoryTrainingLocal GetWiderIn28Days =
            new("How to Get WIDER in 28 Days", "https://www.youtube.com/watch?v=gdXLJiFfR6M");

        public static readonly MandatoryTrainingLocal ObliqueUpperAbsLowerAbs =
            new("ABS Workout At Home For Men", "https://www.youtube.com/watch?v=vICVYyx22AY");

        public static readonly MandatoryTrainingLocal ThreeMinutePause =
            new("3 Minute Pause", "https://www.youtube.com/watch?v=YAIKQT3k42Y");
    }
}