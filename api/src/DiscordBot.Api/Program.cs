using DiscordBot.Api;
using DiscordBot.Core.Constants;
using DiscordBot.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text.Json.Serialization;

LoadEnvironmentVariables();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration.ConfigureLogging();
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDomainAndDataServices();

builder.Services.ConfigureFirebaseAuth(EnvironmentVariables.FirebaseProjectId);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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
