using System.Threading.Tasks;
using Discordbot.WatchTogether.Data;
using DiscordBot.Commands;
using DiscordBot.Commands.Dice;
using DiscordBot.Commands.Dragonball;
using DiscordBot.Commands.Helper;
using DiscordBot.Commands.Memes;
using DiscordBot.Commands.WatchTogether;
using DiscordBot.Core.Constants;
using DiscordBot.Memes.Data;
using DotNetEnv;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot.Service
{
    internal class Program
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

            var commandsConfiguration = new CommandsNextConfiguration
            {
                StringPrefixes = new[] {CommandPrefix.StandardPrefix},
                Services = CreateServices()
            };

            var commands = discord.UseCommandsNext(commandsConfiguration);

            commands.RegisterCommands<RandomDragonballCharacterModule>();
            commands.RegisterCommands<DiceModule>();
            commands.RegisterCommands<RandomMemeModule>();
            commands.RegisterCommands<WatchTogetherModule>();

            commands.SetHelpFormatter<CustomHelpFormatter>();

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
                .AddDragonBallServices()
                .AddDiceServices()
                .AddMemesServices()
                .AddWatchTogetherServices()
                .BuildServiceProvider();
        }

        private static void LoadEnvironmentVariables()
        {
            Env.TraversePath().Load();
        }
    }
}