using System;

namespace DiscordBot.Core.Constants
{
    public static class EnvironmentVariables
    {
        public static readonly string? DopplerToken = Environment.GetEnvironmentVariable("DOPPLER_TOKEN");
    }
}