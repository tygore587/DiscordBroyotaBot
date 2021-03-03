using System;

namespace DiscordBot.Core.Constants
{
    public static class EnvironmentVariables
    {
        public static readonly string Token = Environment.GetEnvironmentVariable("TOKEN");
        public static readonly string WatchTogetherApiKey = Environment.GetEnvironmentVariable("WATCHTOGETHERAPIKEY");
    }
}