using DisCatSharp.ApplicationCommands.Context;
using DisCatSharp.CommandsNext;
using DiscordBot.Commands.Extensions;

namespace DiscordBot.Commands.Logging
{
    public static class LoggingContextExtensions
    {
        public static LoggingContext ToLoggingContext(this CommandContext context)
        {
            return new(context.GetAuthorId(), context.GetGuildId());
        }

        public static LoggingContext ToLoggingContext(this InteractionContext context)
        {
            return new(context.GetAuthorId(), context.GetGuildId());
        }
    }
}