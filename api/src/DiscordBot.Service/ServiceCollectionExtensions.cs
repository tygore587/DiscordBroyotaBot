using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;

namespace DiscordBot.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureLogging(this IServiceCollection serviceCollection)
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithExceptionDetails()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            return serviceCollection.AddSingleton<ILogger>(logger);
        }
    }
}