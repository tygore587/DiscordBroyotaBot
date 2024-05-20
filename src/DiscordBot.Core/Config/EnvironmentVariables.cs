using System;

namespace DiscordBot.Core.Constants
{
    public static class EnvironmentVariables
    {
        public static readonly string Token = Environment.GetEnvironmentVariable("TOKEN") ?? string.Empty;
        public static readonly string WatchTogetherApiKey = Environment.GetEnvironmentVariable("WATCHTOGETHERAPIKEY") ?? string.Empty;
    }
}