using DiscordBot.Data.Dragonball.DataSources;
using DiscordBot.Domain.Dragonball.Repositories;
using System.Collections.Generic;

namespace DiscordBot.Data.Dragonball
{
    internal class DragonballRepository : IDragonballRepository
    {
        private readonly IDragonballCharacterPropertiesLocalDataSource _localDataSource;

        public DragonballRepository(IDragonballCharacterPropertiesLocalDataSource localDataSource)
        {
            _localDataSource = localDataSource;
        }

        public List<string> GetDragonballCharacterNames()
        {
            return _localDataSource.GetCharacterNames();
        }

        public List<string> GetAssists()
        {
            return _localDataSource.GetAssistVariants();
        }

        public int GetColorVariants()
        {
            return _localDataSource.GetColorVariants();
        }
    }
}