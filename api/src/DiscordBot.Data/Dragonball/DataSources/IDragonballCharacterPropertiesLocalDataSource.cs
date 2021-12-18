using System.Collections.Generic;

namespace DiscordBot.Data.Dragonball.DataSources
{
    public interface IDragonballCharacterPropertiesLocalDataSource
    {
        List<string> GetCharacterNames();
        List<string> GetAssistVariants();
        int GetColorVariants();
    }
}