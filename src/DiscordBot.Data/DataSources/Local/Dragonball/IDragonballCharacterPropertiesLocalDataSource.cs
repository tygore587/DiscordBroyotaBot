using System.Collections.Generic;

namespace DiscordBot.Data.DataSources.Local.Dragonball
{
    public interface IDragonballCharacterPropertiesLocalDataSource
    {
        List<string> GetCharacterNames();
        List<string> GetAssistVariants();
        int GetColorVariants();
    }
}