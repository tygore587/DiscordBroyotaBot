using System;
using DiscordBot.Dice.Domain.Entities;
using DiscordBot.Dice.Domain.UseCases;
using DiscordBot.Dragonball.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot.Service
{
    public static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddDragonBallServices(this IServiceCollection services)
        {
            return services?
                .AddSingleton<Random>()
                .AddSingleton<GetRandomCharacters>();
        }

        internal static IServiceCollection AddDiceServices(this IServiceCollection services)
        {
            return services?
                .AddSingleton<Random>()
                .AddSingleton<Die>()
                .AddSingleton<RollDice>();
        }
    }
}