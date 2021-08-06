using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.SaschaHuber
{
    public abstract class SaschaTrainings
    {
        public static readonly MandatoryTrainingLocal ThreeMinuteWarmup =
            new("Three minute warmup", "https://youtu.be/B1qXC1qlzcA");

        public static readonly MandatoryTrainingLocal Chest = new("Chest", "https://youtu.be/ZXSHhDulDkM");

        public static readonly MandatoryTrainingLocal Shoulders = new("Shoulders", "https://youtu.be/WMablLMqKeI");

        public static readonly OptionalTrainingLocal ShouldersNoWeights =
            new("Shoulders No weights", "https://youtu.be/WMablLMqKeI");

        public static readonly MandatoryTrainingLocal SixMinuteSixPack =
            new("Six minute Six pack", "https://youtu.be/raHbcZqXWBY");

        public static readonly MandatoryTrainingLocal Biceps = new("Biceps", "https://youtu.be/mT6jAV5mkBA");

        public static readonly MandatoryTrainingLocal Triceps = new("Triceps", "https://youtu.be/66ukErqqC2I");

        public static readonly MandatoryTrainingLocal Back1 = new("Back Nr. 1", "https://youtu.be/25fxE9VrmPs");

        public static readonly MandatoryTrainingLocal Legs1 = new("Legs Nr. 1", "https://youtu.be/qQ5vFMxi74o");

        public static readonly MandatoryTrainingLocal TenMinuteSixPack =
            new("10 Minute Six pack", "https://youtu.be/iBHhj6AQ75I");

        public static readonly MandatoryTrainingLocal UpperBody = new("Upper Body", "https://youtu.be/qGCCVFrsN0Y");

        public static readonly MandatoryTrainingLocal Back2 = new("Back Nr. 2", "https://youtu.be/vwLV2sCSQEo");

        public static readonly MandatoryTrainingLocal Legs2 = new("Legs Nr. 2", "https://youtu.be/OU9OpJIFt0Y");
    }
}