using System;
using System.Threading.Tasks;
using DiscordBot.Commands;
using DiscordBot.Commands.Helper;
using DiscordBot.Commands.Modules.Chat;
using DiscordBot.Commands.Modules.Slash;
using DiscordBot.Core.Constants;
using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Data;
using DotNetEnv;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DiscordBot.Service
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
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
                .RegisterChatCommands(serviceProvider)
                .RegisterSlashCommands(serviceProvider);

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

            if (string.IsNullOrWhiteSpace(EnvironmentVariables.SlashCommandsGuildId))
            {
                logger?.Warning(
                    "Environment variable SLASH_COMMANDS_GUILD_ID was not set: Do not register slash commands");
                return discord;
            }

            if (!ulong.TryParse(EnvironmentVariables.SlashCommandsGuildId, out var guildId))
            {
                logger?.Warning(
                    "Unable to parse SLASH_COMMANDS_GUILD_ID to ulong. SLASH_COMMANDS_GUILD_ID: {SlashCommandsGuildId}",
                    EnvironmentVariables.SlashCommandsGuildId);
                return discord;
            }

            var slashConfiguration = new SlashCommandsConfiguration
            {
                Services = services
            };

            var slash = discord.UseSlashCommands(slashConfiguration);

            slash.RegisterCommands<DiceSlashModule>(guildId);

            return discord;
        }

        private static DiscordClient RegisterChatCommands(this DiscordClient discord, IServiceProvider services)
        {
            var commandsConfiguration = new CommandsNextConfiguration
            {
                StringPrefixes = new[] {CommandPrefix.StandardPrefix},
                Services = services
            };

            var commands = discord.UseCommandsNext(commandsConfiguration);

            commands.RegisterCommands<DragonballCharacterChatModule>();
            commands.RegisterCommands<DiceChatModule>();
            commands.RegisterCommands<MemeChatModule>();
            commands.RegisterCommands<WatchTogetherChatModule>();
            commands.RegisterCommands<NewsChatModule>();

            commands.SetHelpFormatter<CustomHelpFormatter>();

            return discord;
        }

        private static void LoadEnvironmentVariables()
        {
            Env.TraversePath().Load();
        }
    }
}