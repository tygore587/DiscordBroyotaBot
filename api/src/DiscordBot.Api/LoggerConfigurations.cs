using Serilog;
using Serilog.Exceptions;

namespace DiscordBot.Api
{
    public static class LoggerConfigurations
    {
        public static LoggerConfiguration ConfigureLogging(this LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration
                 .Enrich.WithExceptionDetails()
                 .MinimumLevel.Information()
                 .WriteTo.Console();

            return loggerConfiguration;
        }
    }

}
