using System;

namespace DiscordBot.Core
{
    public static class EnvironmentVariables
    {
        public static readonly string Token = Environment.GetEnvironmentVariable("TOKEN");
    }
}