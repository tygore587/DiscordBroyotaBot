using DisCatSharp;
using DisCatSharp.ApplicationCommands;
using DisCatSharp.ApplicationCommands.EventArgs;
using DisCatSharp.CommandsNext;
using DisCatSharp.Enums;
using DiscordBot.Commands;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Helper;
using DiscordBot.Commands.Modules.Slash;
using DiscordBot.Commands.Modules.Slash.Trainings;
using DiscordBot.Core.Constants;
using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Data;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    internal static class Program
    {
        private static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            SetupConfigurations();

            var discordConfiguration = new DiscordConfiguration
            {
                Token = EnvironmentVariables.Token,
                TokenType = TokenType.Bot
            };

            var discord = new DiscordClient(discordConfiguration);

            var serviceProvider = CreateServices();

            discord
                .RegisterSlashCommands(serviceProvider)
                .RegisterChatCommands(serviceProvider);

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private static void SetupConfigurations()
        {
            LoadEnvironmentVariables();
        }

        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .ConfigureLogging()
                .AddSingleton<IDateTimeProvider, DateTimeProvider>()
                .AddCommandDependencies()
                .AddDomainAndDataServices()
                .BuildServiceProvider();
        }

        private static DiscordClient RegisterSlashCommands(this DiscordClient discord, IServiceProvider services)
        {
            var logger = services.GetService<ILogger>();

            var slashConfiguration = new ApplicationCommandsConfiguration(services);

            var slash = discord.UseApplicationCommands(slashConfiguration);

            slash.RegisterGlobalCommands<DiceSlashModule>();
            slash.RegisterGlobalCommands<DragonballGroupModule>();
            slash.RegisterGlobalCommands<MemeSlashModule>();
            slash.RegisterGlobalCommands<RedditMemeSlashModule>();
            slash.RegisterGlobalCommands<NewsSlashModule>();
            slash.RegisterGlobalCommands<WatchTogetherSlashModule>();
            slash.RegisterGlobalCommands<TrainingsSlashModule>();
            slash.RegisterGlobalCommands<YoutubeSlashModule>();

            slash.SlashCommandErrored += (_, commandArgs) => HandleSlashCommandErrors(logger, commandArgs);

            return discord;
        }
        
        private static Task HandleSlashCommandErrors(ILogger? logger, SlashCommandErrorEventArgs eventArgs)
        {
            var exception = eventArgs.Exception;
            var context = eventArgs.Context;

            logger?.Error(eventArgs.Exception,
                "An error occured while running a command. Guild ID: {GuildId} | Command Name: {CommandName}",
                context.GetGuildId(), context.CommandName);

            return context.RespondWithError(
                $"An unexpected error happened while running the command. Please contact the developer. The error message was: {exception.Message}");
        }

        private static DiscordClient RegisterChatCommands(this DiscordClient discord, IServiceProvider services)
        {
            var commandsConfiguration = new CommandsNextConfiguration(services)
            {
                StringPrefixes = new() { CommandPrefix.StandardPrefix },
            };

            var commands = discord.UseCommandsNext(commandsConfiguration);

            commands.SetHelpFormatter<CustomHelpFormatter>();

            var logger = services.GetService<ILogger>();

            logger?.Information("Registered chat modules. Modules: {@Modules}",
                commands.RegisteredCommands.Select(c => c.Key));

            return discord;
        }

        private static void LoadEnvironmentVariables()
        {
            Env.TraversePath().Load();
        }
    }
}