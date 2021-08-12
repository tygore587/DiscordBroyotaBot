using DiscordBot.Data.Trainings.Models;

namespace DiscordBot.Data.Trainings.DataSources.Local.SaschaHuber
{
    public abstract class SaschaTrainings
    {
        public static readonly TrainingLocal ThreeMinuteWarmup =
            new("Three minute warmup", "https://youtu.be/B1qXC1qlzcA");

        public static readonly TrainingLocal Chest = new("Chest", "https://youtu.be/ZXSHhDulDkM");

        public static readonly TrainingLocal Shoulders = new("Shoulders", "https://youtu.be/WMablLMqKeI");

        public static readonly TrainingLocal ShouldersNoWeights =
            new("Shoulders No weights", "https://youtu.be/WMablLMqKeI");

        public static readonly TrainingLocal SixMinuteSixPack =
            new("Six minute Six pack", "https://youtu.be/raHbcZqXWBY");

        public static readonly TrainingLocal Biceps = new("Biceps", "https://youtu.be/mT6jAV5mkBA");

        public static readonly TrainingLocal Triceps = new("Triceps", "https://youtu.be/66ukErqqC2I");

        public static readonly TrainingLocal Back1 = new("Back Nr. 1", "https://youtu.be/25fxE9VrmPs");

        public static readonly TrainingLocal Legs1 = new("Legs Nr. 1", "https://youtu.be/qQ5vFMxi74o");

        public static readonly TrainingLocal TenMinuteSixPack =
            new("10 Minute Six pack", "https://youtu.be/iBHhj6AQ75I");

        public static readonly TrainingLocal UpperBody = new("Upper Body", "https://youtu.be/qGCCVFrsN0Y");

        public static readonly TrainingLocal Back2 = new("Back Nr. 2", "https://youtu.be/vwLV2sCSQEo");

        public static readonly TrainingLocal Legs2 = new("Legs Nr. 2", "https://youtu.be/OU9OpJIFt0Y");

        public static readonly TrainingLocal Chest5Minutes = new("Chest Stamina", "https://youtu.be/wZ7ZzalCI4k");

        public static readonly TrainingLocal Shoulders5Minutes = new("Shoulders Stamina", "https://youtu.be/Cknm5JQp2hg");

        public static readonly TrainingLocal Biceps5Minutes = new("Biceps Stamina", "https://youtu.be/_XchEBmGugk");

        public static readonly TrainingLocal Triceps5Minutes = new("Triceps Stamina", "https://youtu.be/0WEot369EfE");
    }
}