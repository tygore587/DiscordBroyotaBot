using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordBot.Core.Commands.Dragonball
{
    public static class DragonballCharacters
    {
        private static IReadOnlyCollection<string> _characters = new []
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

        private static IReadOnlyCollection<string> _assists = new[]
        {
            "A",
            "B",
            "C"
        };

        private static int Colors = 15;
        
        public static List<DragonballCharacter> GetRandomCharacters()
        {
            var random = new Random();
            var firstCharacter = 0;
            var secondCharacter = 0;
            var thirdCharacter = 0;

            var characterCount = _characters.Count;

            while (firstCharacter == secondCharacter 
                   && firstCharacter == secondCharacter 
                   && secondCharacter == thirdCharacter)
            {
                firstCharacter = random.Next(characterCount);
                secondCharacter = random.Next(characterCount);
                thirdCharacter = random.Next(characterCount);
            }

            var assistCount = _assists.Count;
            var firstRandomAssist = random.Next(assistCount);
            var secondRandomAssist = random.Next(assistCount);
            var thirdRandomAssist = random.Next(assistCount);
            
            return  new List<DragonballCharacter>
                {
                    new(_characters.ElementAt(firstCharacter),_assists.ElementAt(firstRandomAssist),random.Next(Colors)),
                    new(_characters.ElementAt(secondCharacter),_assists.ElementAt(secondRandomAssist),random.Next(Colors)),
                    new(_characters.ElementAt(thirdCharacter),_assists.ElementAt(thirdRandomAssist),random.Next(Colors)),
                };
        }
    }
}