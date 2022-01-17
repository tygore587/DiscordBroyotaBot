using System;

namespace DiscordBot.Core.Constants
{
    public static class EnvironmentVariables
    {
        public static readonly string? Token = Environment.GetEnvironmentVariable("TOKEN");
        public static readonly string? WatchTogetherApiKey = Environment.GetEnvironmentVariable("WATCHTOGETHERAPIKEY");

        public static readonly string? SlashCommandsGuildId =
            Environment.GetEnvironmentVariable("SLASH_COMMANDS_GUILD_ID");

        public static readonly string? FirebaseProjectId = Environment.GetEnvironmentVariable("FIREBASE_PROJECT_ID");
    }
}