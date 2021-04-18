using System;

namespace DiscordBot.Core.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
        DateTime Today();
    }
}