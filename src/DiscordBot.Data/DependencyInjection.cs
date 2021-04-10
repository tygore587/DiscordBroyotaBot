using System;
using DiscordBot.Data.DataSources.Local.Dragonball;
using DiscordBot.Data.DataSources.Local.Dragonball.Provider;
using DiscordBot.Data.DataSources.Local.News;
using DiscordBot.Data.DataSources.Remote.Memes;
using DiscordBot.Data.DataSources.Remote.News;
using DiscordBot.Data.DataSources.Remote.WatchTogether;
using DiscordBot.Data.Repositories;
using DiscordBot.Domain.Repositories;
using DiscordBot.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace DiscordBot.Data
{
    public static class DependencyInjection
    {
        private static readonly RefitSettings RefitJsonSettings = new(new NewtonsoftJsonContentSerializer());

        private static readonly RefitSettings RefitXmlSettings = new(new XmlContentSerializer());

        public static IServiceCollection AddDomainAndDataServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<Random>()
                .AddDiceServices()
                .AddDragonballServices()
                .AddMemesServices()
                .AddNewsServices()
                .AddWatchTogetherServices();
        }

        private static IServiceCollection ConfigureRefitClient<T>(this IServiceCollection services, string baseUrl,
            RefitSettings settings) where T : class
        {
            services
                .AddRefitClient<T>(settings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }

        private static IServiceCollection AddDiceServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<RollDice>();
        }

        private static IServiceCollection AddMemesServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMemesRepository, MemesRepository>()
                .AddSingleton<IMemesRemoteDataSource, MemesRemoteDataSource>()
                .ConfigureRefitClient<IMemeApi>(IMemeApi.BaseUrl, RefitJsonSettings)
                .AddSingleton<GetRandomMeme>();
        }

        private static IServiceCollection AddNewsServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<INewsRepository, NewsRepository>()
                .AddSingleton<ITagesschauRemoteDataSource, TagesschauRemoteDataSource>()
                .ConfigureRefitClient<ITagesschauApi>(ITagesschauApi.BaseUrl, RefitXmlSettings)
                .AddSingleton<INewsLocalCacheDataSource, NewsLocalCacheDataSource>()
                .AddSingleton<GetTagesschauNews>();
        }

        private static IServiceCollection AddWatchTogetherServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IWatchTogetherRepository, WatchTogetherRepository>()
                .AddSingleton<IWatchTogetherRemoteDataSource, WatchTogetherRemoteDataSource>()
                .ConfigureRefitClient<IWatchTogetherApi>(IWatchTogetherApi.BaseUrl, RefitJsonSettings)
                .AddSingleton<CreateWatchTogetherRoom>();
        }

        private static IServiceCollection AddDragonballServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDragonballRepository, DragonballRepository>()
                .AddSingleton<IDragonballCharacterPropertiesLocalDataSource,
                    DragonballCharacterPropertiesLocalDataSource>()
                .AddSingleton<GetRandomCharacters>()
                .AddSingleton<IDragonballCharacterPropertyProvider, DragonballCharacterPropertyProvider>();
        }
    }
}