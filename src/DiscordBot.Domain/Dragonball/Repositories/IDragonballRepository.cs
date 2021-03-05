using System.Collections.Generic;

namespace DiscordBot.Domain.Dragonball.Repositories
{
    public interface IDragonballRepository
    {
        List<string> GetDragonballCharacterNames();

        List<string> GetAssists();
        int GetColorVariants();
    }
}