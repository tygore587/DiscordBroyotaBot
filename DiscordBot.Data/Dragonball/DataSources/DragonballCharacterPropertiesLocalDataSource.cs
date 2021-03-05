using System.Collections.Generic;
using System.Linq;

namespace DiscordBot.Data.Dragonball.DataSources
{
    internal class DragonballCharacterPropertiesLocalDataSource : IDragonballCharacterPropertiesLocalDataSource
    {
        private const int NumberOfColors = 15;

        private static readonly IReadOnlyCollection<string> CharacterNames = new[]
        {
            "Android 16",
            "Android 18",
            "Android 21",
            "Beerus",
            "Captain Ginyu",
            "Cell",
            "Frieza",
            "Gohan (Teen)",
            "Gohan (Adult)",
            "Goku (Super Saiyan)",
            "Goku (SSGSS)",
            "Goku Black",
            "Gotenks",
            "Hit",
            "Kid Buu",
            "Krillin",
            "Majin Buu",
            "Nappa",
            "Piccolo",
            "Tien Shinhan",
            "Trunks",
            "Vegeta (Super Saiyan)",
            "Vegeta (SSGSS) Z",
            "Yamcha",
            "Android 17",
            "Bardock",
            "Broly",
            "Cooler",
            "Goku",
            "Vegeta",
            "Vegito (SSGSS)",
            "Zamasu (Fused)",
            "Broly (DBS)",
            "Gogeta (SSGSS)",
            "Goku (GT)",
            "Janemba",
            "Jiren",
            "Videl",
            "Goku (Ultra Instinct)",
            "Kefla",
            "Muten Roshi",
            "Super Baby Vegeta"
        };

        private static readonly IReadOnlyCollection<string> Assists = new[]
        {
            "A",
            "B",
            "C"
        };

        public List<string> GetCharacterNames()
        {
            return CharacterNames.ToList();
        }

        public List<string> GetAssistVariants()
        {
            return Assists.ToList();
        }

        public int GetNumberOfColors()
        {
            return NumberOfColors;
        }
    }
}