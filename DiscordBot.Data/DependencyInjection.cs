﻿using System;
using DiscordBot.Data.Dragonball.DataSources;
using DiscordBot.Data.Dragonball.Repositories;
using DiscordBot.Data.Memes.DataSources;
using DiscordBot.Data.Memes.Repositories;
using DiscordBot.Data.Requests;
using DiscordBot.Data.WatchTogether.DataSources;
using DiscordBot.Data.WatchTogether.Repositories;
using DiscordBot.Domain.Dice.Entities;
using DiscordBot.Domain.Dice.UseCases;
using DiscordBot.Domain.Dragonball.Repositories;
using DiscordBot.Domain.Dragonball.UseCases;
using DiscordBot.Domain.Memes.Repositories;
using DiscordBot.Domain.Memes.UseCases;
using DiscordBot.WatchTogether.Domain.Repositories;
using DiscordBot.WatchTogether.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainAndDataServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<Random>()
                .AddSingleton<IRequestClient, RequestClient>()
                .AddDiceServices()
                .AddDragonballServices()
                .AddMemesServices()
                .AddWatchTogetherServices();
        }

        private static IServiceCollection AddDiceServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<Die>()
                .AddSingleton<RollDice>();
        }

        private static IServiceCollection AddMemesServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMemesRemoteDataSource, MemesRemoteDataSource>()
                .AddSingleton<IMemesRepository, MemesRepository>()
                .AddSingleton<GetRandomMeme>();
        }

        private static IServiceCollection AddWatchTogetherServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IWatchTogetherRepository, WatchTogetherRepository>()
                .AddSingleton<IWatchTogetherRemoteDataSource, WatchTogetherRemoteDataSource>()
                .AddSingleton<CreateWatchTogetherRoom>();
        }

        private static IServiceCollection AddDragonballServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDragonballRepository, DragonballRepository>()
                .AddSingleton<IDragonballCharacterPropertiesLocalDataSource,
                    DragonballCharacterPropertiesLocalDataSource>()
                .AddSingleton<GetRandomCharacters>();
        }
    }
}