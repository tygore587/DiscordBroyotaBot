using System.Threading.Tasks;
using DiscordBot.Commands;
using DiscordBot.Commands.Die;
using DiscordBot.Core.Commands.Dragonball;
using DotNetEnv;
using DSharpPlus;
using DSharpPlus.CommandsNext;

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
                StringPrefixes = new[] {CommandPrefix.StandardPrefix}
            };

            var commands = discord.UseCommandsNext(commandsConfiguration);

            commands.RegisterCommands<DragonballModule>();
            commands.RegisterCommands<DieModule>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private static void SetupConfigurations()
        {
            LoadEnvironmentVariables();
        }

        private static void LoadEnvironmentVariables()
        {
            Env.TraversePath().Load();
        }
    }
}