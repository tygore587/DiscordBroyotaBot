using System.Collections.Generic;

namespace DiscordBot.Domain.Dragonball.Models
{
    public static class DragonballDefaults
    {
        public static IReadOnlyCollection<string> CharacterNames = new[]
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
            "Tien Shinhan A",
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

        public static IReadOnlyCollection<string> Assists = new[]
        {
            "A",
            "B",
            "C"
        };

        public static readonly int NumberOfColors = 15;
    }
}