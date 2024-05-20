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
            discord.RegisterSlashCommands(services, EnvironmentVariables.SlashCommandsGuildId);

            return discord.RegisterSlashCommands(services, EnvironmentVariables.SlashCommandsGuildId2);
        }

        private static DiscordClient RegisterSlashCommands(this DiscordClient discord, IServiceProvider services, string guildId)
        {
            var logger = services.GetService<ILogger>();

            if (string.IsNullOrWhiteSpace(guildId))
            {
                logger?.Warning(
                    "guildId was not set: Do not register slash commands");
                return discord;
            }

            if (!ulong.TryParse(EnvironmentVariables.SlashCommandsGuildId, out var guildIdNumber))
            {
                logger?.Warning(
                    "Unable to parse guild ID to ulong. Guild ID: {SlashCommandsGuildId}",
                    EnvironmentVariables.SlashCommandsGuildId);
                return discord;
            }

            var slashConfiguration = new ApplicationCommandsConfiguration(services);

            var slash = discord.UseApplicationCommands(slashConfiguration);

            slash.RegisterGuildCommands<DiceSlashModule>(guildIdNumber);
            slash.RegisterGuildCommands<DragonballGroupModule>(guildIdNumber);
            slash.RegisterGuildCommands<MemeSlashModule>(guildIdNumber);
            slash.RegisterGuildCommands<RedditMemeSlashModule>(guildIdNumber);
            slash.RegisterGuildCommands<NewsSlashModule>(guildIdNumber);
            slash.RegisterGuildCommands<WatchTogetherSlashModule>(guildIdNumber);
            slash.RegisterGuildCommands<TrainingsSlashModule>(guildIdNumber);
            slash.RegisterGuildCommands<YoutubeSlashModule>(guildIdNumber);

            slash.SlashCommandErrored += (_, commandArgs) => HandleSlashCommandErrors(logger, commandArgs);

            logger?.Information("Registered slash commands. Guild: {GuildId}", guildId);

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