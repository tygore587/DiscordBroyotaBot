using System;

namespace DiscordBot.Service
{
    public static class EnvironmentVariables
    {
        public static readonly string Token = Environment.GetEnvironmentVariable("TOKEN");
    }
}