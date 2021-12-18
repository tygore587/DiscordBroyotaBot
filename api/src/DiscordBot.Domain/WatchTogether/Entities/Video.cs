using System;
namespace DiscordBot.Domain.WatchTogether.Entities
{
    public record Video(string Url, string? Title = null,string? ThumbnailLink = null);
}
