using System;
using System.Threading.Tasks;
using DiscordBot.Core.Commands;
using DiscordBot.Core.Commands.Dragonball;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace DiscordBot.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            SetupConfigurations();

            var discordConfiguration = new DiscordConfiguration
            {
                Token = EnvironmentVariables.Token,
                TokenType = TokenType.Bot,
            };
            
            
            
            var discord = new DiscordClient(discordConfiguration);

            var commandsConfiguration = new CommandsNextConfiguration
            {
                StringPrefixes = new[] {CommandPrefix.StandardPrefix},
            };

            var commands = discord.UseCommandsNext(commandsConfiguration);

            commands.RegisterCommands<DragonballRandomizer>();
            
            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
        private static void SetupConfigurations()
        {
            LoadEnvironmentVariables();
        }

        
        private static void LoadEnvironmentVariables()
        {
            DotNetEnv.Env.TraversePath().Load();
        }
    }
}