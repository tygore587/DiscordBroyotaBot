using System.Collections.Generic;

namespace DiscordBot.Data.Dragonball.DataSources
{
    internal interface IDragonballCharacterPropertiesLocalDataSource
    {
        List<string> GetCharacterNames();
        List<string> GetAssistVariants();
        int GetNumberOfColors();
    }
}