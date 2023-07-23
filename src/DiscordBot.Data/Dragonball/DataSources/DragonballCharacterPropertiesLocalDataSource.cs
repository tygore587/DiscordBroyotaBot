using DiscordBot.Data.Dragonball.DataSources.Provider;
using System.Collections.Generic;
using System.Linq;

namespace DiscordBot.Data.Dragonball.DataSources
{
    internal class DragonballCharacterPropertiesLocalDataSource : IDragonballCharacterPropertiesLocalDataSource
    {
        private readonly IDragonballCharacterPropertyProvider _characterPropertyProvider;

        public DragonballCharacterPropertiesLocalDataSource(
            IDragonballCharacterPropertyProvider characterPropertyProvider)
        {
            _characterPropertyProvider = characterPropertyProvider;
        }

        public List<string> GetCharacterNames()
        {
            return _characterPropertyProvider.GetCharacterNames().ToList();
        }

        public List<string> GetAssistVariants()
        {
            return _characterPropertyProvider.GetAssists().ToList();
        }

        public int GetColorVariants()
        {
            return _characterPropertyProvider.GetColorOptions();
        }
    }
}