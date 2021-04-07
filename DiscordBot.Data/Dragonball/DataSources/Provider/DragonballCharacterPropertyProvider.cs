using System.Collections.Generic;

namespace DiscordBot.Data.Dragonball.DataSources.Provider
{
    public class DragonballCharacterPropertyProvider : IDragonballCharacterPropertyProvider
    {
        public IEnumerable<string> GetCharacterNames()
        {
            return DragonballProperties.CharacterNames;
        }

        public int GetColorOptions()
        {
            return DragonballProperties.ColorOptions;
        }

        public IEnumerable<string> GetAssists()
        {
            return DragonballProperties.Assists;
        }
    }
}