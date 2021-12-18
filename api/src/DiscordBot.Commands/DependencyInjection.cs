using DiscordBot.Commands.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot.Commands
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommandDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<ICommandLogger, CommandLogger>();
        }
    }
}