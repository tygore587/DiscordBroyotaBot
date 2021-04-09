using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DiscordBot.Data.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace DiscordBot.Data.Dragonball.DataSources
{
    internal interface IDragonballCharacterPropertiesLocalDataSource
    {
        List<string> GetCharacterNames();
        List<string> GetAssistVariants();
        int GetColorVariants();
    }
}