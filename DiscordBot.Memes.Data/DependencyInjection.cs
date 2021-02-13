using Discordbot.Memes.Domain.Repositories;
using Discordbot.Memes.Domain.Usecases;
using DiscordBot.Core.Data.Requests;
using DiscordBot.Memes.Data.DataSources;
using DiscordBot.Memes.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot.Memes.Data
{
    public static class MemesDependencyInjection
    {
        public static IServiceCollection AddMemesToServices(this IServiceCollection services)
        {
            return services?
                .AddSingleton<IMemesRemoteDataSource, MemesRemoteDataSource>()
                .AddSingleton<IMemesRepository, MemesRepository>()
                .AddSingleton<GetRandomMeme>()
                .AddSingleton<IRequestClient, RequestClient>();
        }
    }
}