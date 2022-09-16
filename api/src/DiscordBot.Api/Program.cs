using DiscordBot.Api;
using DiscordBot.Api.Secrets;
using DiscordBot.Core.Constants;
using DiscordBot.Core.Secrets;
using DiscordBot.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text.Json.Serialization;

LoadEnvironmentVariables();

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

builder.ConfigureControllers();

await builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();

static void LoadEnvironmentVariables()
{
    Env.TraversePath().Load();
}



static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureFirebaseAuth(this IServiceCollection services, string? projectId)
    {
        if (projectId == null)
            throw new ArgumentNullException(nameof(projectId), "Firebase Project ID can't be null or empty.");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.Authority = $"https://securetoken.google.com/{projectId}";
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidIssuer = $"https://securetoken.google.com/{projectId}",
                   ValidateAudience = true,
                   ValidAudience = projectId,
                   ValidateLifetime = true
               };
           });

        return services;
    }
}

static class WebApplicationBuilderExtensions
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration.ConfigureLogging();
        });
    }

    public static void ConfigureControllers(this WebApplicationBuilder builder)
    {
        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }

    public static async Task ConfigureServices(this WebApplicationBuilder builder)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddDomainAndDataServices();

        var secrets = await GetSecretsFromDoppler();

        if (secrets == null)
            throw new ArgumentNullException(nameof(secrets), "Secrets from doppler were null or empty.");

        builder.Services.ConfigureFirebaseAuth(secrets.FirebaseProjectId);
        builder.Services.AddSingleton(secrets);

        static async Task<ApplicationSecrets?> GetSecretsFromDoppler()
        {
            var dopplerToken = EnvironmentVariables.DopplerToken;

            if (string.IsNullOrWhiteSpace(dopplerToken))
                throw new ArgumentNullException(nameof(dopplerToken), "Doppler Token was null or empty from environment.");

            return await DopplerSecretClient.FetchSecrets(dopplerToken);
        }
    }
}