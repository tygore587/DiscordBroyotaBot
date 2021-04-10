using System.Collections.Generic;

namespace DiscordBot.Domain.Repositories
{
    public interface IDragonballRepository
    {
        List<string> GetDragonballCharacterNames();

        List<string> GetAssists();
        int GetColorVariants();
    }
}