using System;
using DiscordBot.Data.Dragonball;
using DiscordBot.Data.Dragonball.DataSources;
using DiscordBot.Data.Dragonball.DataSources.Provider;
using DiscordBot.Data.Memes;
using DiscordBot.Data.Memes.DataSources;
using DiscordBot.Data.News;
using DiscordBot.Data.News.DataSources.Local;
using DiscordBot.Data.News.DataSources.Remote.Tagesschau;
using DiscordBot.Data.Trainings.DataSources.Local;
using DiscordBot.Data.Trainings.DataSources.Local.IgorVoitenko;
using DiscordBot.Data.Trainings.DataSources.Local.SaschaHuber;
using DiscordBot.Data.Trainings.Repositories;
using DiscordBot.Data.WatchTogether;
using DiscordBot.Data.WatchTogether.DataSources;
using DiscordBot.Data.Youtube;
using DiscordBot.Data.Youtube.DataSources.Local;
using DiscordBot.Data.Youtube.DataSources.Remote;
using DiscordBot.Domain.Dies.UseCases;
using DiscordBot.Domain.Dragonball.Repositories;
using DiscordBot.Domain.Dragonball.UseCases;
using DiscordBot.Domain.Memes.Repositories;
using DiscordBot.Domain.Memes.UseCases;
using DiscordBot.Domain.News.Repositories;
using DiscordBot.Domain.News.UseCases;
using DiscordBot.Domain.Trainings.Repositories;
using DiscordBot.Domain.Trainings.UseCases;
using DiscordBot.Domain.WatchTogether.Repositories;
using DiscordBot.Domain.WatchTogether.UseCases;
using DiscordBot.Domain.Youtube.Repositories;
using DiscordBot.Domain.Youtube.UseCases;
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
                .AddWatchTogetherServices()
                .AddTrainingsServices()
                .AddYoutubeLinkServices();
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

        private static IServiceCollection AddTrainingsServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IIgorVoitenkoProvider, IgorVoitenkoProvider>()
                .AddSingleton<ISaschaHuberProvider, SaschaHuberProvider>()
                .AddSingleton<ITrainingLocalDataSource, TrainingLocalDataSource>()
                .AddSingleton<ITrainingsRepository, TrainingsRepository>()
                .AddSingleton<ITrainingsStartProvider, TrainingsStartProvider>()
                .AddSingleton<GetTodayTraining>();
        }

        private static IServiceCollection AddYoutubeLinkServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IYoutubeLocalCacheDataSource, YoutubeLocalCacheDataSource>()
                .AddSingleton<IYoutubeRemoteDataSource, YoutubeRemoteDataSource>()
                .AddSingleton<IYoutubeRepository,YoutubeRepository>()
                .ConfigureRefitClient<IYoutubeRSSApi>(IYoutubeRSSApi.BaseUrl, RefitXmlSettings)
                .AddSingleton<SearchNewestVideoFromChannel>();
        }
    }
}