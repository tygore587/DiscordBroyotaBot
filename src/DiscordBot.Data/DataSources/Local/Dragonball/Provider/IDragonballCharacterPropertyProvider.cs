using System.Collections.Generic;

namespace DiscordBot.Data.DataSources.Local.Dragonball.Provider
{
    public interface IDragonballCharacterPropertyProvider
    {
        IEnumerable<string> GetCharacterNames();
        int GetColorOptions();
        IEnumerable<string> GetAssists();
    }
}