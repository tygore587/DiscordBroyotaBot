using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DiscordBot.Data;
using DiscordBot.Data.DataSources.Local.Dragonball.Provider;

[assembly: InternalsVisibleTo(TestConstants.AssemblyName)]

namespace DiscordBot.Data.DataSources.Local.Dragonball
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