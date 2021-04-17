using System.Collections.Generic;

namespace DiscordBot.Data.Dragonball.DataSources.Provider
{
    public interface IDragonballCharacterPropertyProvider
    {
        IEnumerable<string> GetCharacterNames();
        int GetColorOptions();
        IEnumerable<string> GetAssists();
    }
}