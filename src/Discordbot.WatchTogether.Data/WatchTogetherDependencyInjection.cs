using Discordbot.WatchTogether.Data.DataSources;
using Discordbot.WatchTogether.Data.Repositories;
using DiscordBot.Core.Data.Requests;
using DiscordBot.WatchTogether.Domain.Repositories;
using DiscordBot.WatchTogether.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Discordbot.WatchTogether.Data
{
    public static class WatchTogetherDependencyInjection
    {
        public static IServiceCollection AddWatchTogetherServices(this IServiceCollection services)
        {
            return services?
                .AddSingleton<IWatchTogetherRemoteDataSource, WatchTogetherRemoteDataSource>()
                .AddSingleton<IWatchTogetherRepository, WatchTogetherRepository>()
                .AddSingleton<CreateWatchTogetherRoom>()
                .AddSingleton<IRequestClient, RequestClient>();
        }
    }
}
