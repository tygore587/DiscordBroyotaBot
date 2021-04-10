using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiscordBot.Data;
using DiscordBot.Data.DataSources.Local.Dragonball;
using DiscordBot.Domain.Repositories;

[assembly: InternalsVisibleTo(TestConstants.AssemblyName)]

namespace DiscordBot.Data.Repositories
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