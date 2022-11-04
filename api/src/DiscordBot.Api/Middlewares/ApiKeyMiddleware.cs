using System;
using DiscordBot.Core.Secrets;

namespace DiscordBot.Api.Middlewares;

public class ApiKeyMiddleware
{
    const string API_KEY_HEADER_NAME = "X-Api-Key";

    private readonly ApplicationSecrets _applicationSecrets;

    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(ApplicationSecrets applicationSecrets, RequestDelegate next)
    {
        _applicationSecrets = applicationSecrets;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var apiKey)) {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            var problem = new { message = "No api key provided" };

            await context.Response.WriteAsJsonAsync(problem);

            return;
        }

        if (!string.Equals(apiKey, _applicationSecrets.ApiKey))
        {
            var problem = new { message = "Wrong api key provided" };

            await context.Response.WriteAsJsonAsync(problem);

            return;
        }

        await _next(context);
    }
}

