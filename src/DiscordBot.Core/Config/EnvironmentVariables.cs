using System;

namespace DiscordBot.Core.Constants
{
    public static class EnvironmentVariables
    {
        public static readonly string Token = Environment.GetEnvironmentVariable("TOKEN") ?? string.Empty;
        public static readonly string WatchTogetherApiKey = Environment.GetEnvironmentVariable("WATCHTOGETHERAPIKEY") ?? string.Empty;

        public static readonly string SlashCommandsGuildId =
            Environment.GetEnvironmentVariable("SLASH_COMMANDS_GUILD_ID") ?? string.Empty;

        public static readonly string SlashCommandsGuildId2 =
            Environment.GetEnvironmentVariable("SLASH_COMMANDS_GUILD_ID2") ?? string.Empty;
    }
}