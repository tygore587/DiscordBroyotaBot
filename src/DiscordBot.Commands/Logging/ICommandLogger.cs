using System;
using DSharpPlus.CommandsNext;

namespace DiscordBot.Commands.Logging
{
    public interface ICommandLogger
    {
        void Error(Exception ex, CommandContext context, string messageTemplate, params object[] arguments);
        void Information(CommandContext context, string messageTemplate, params object[] arguments);
        void Debug(CommandContext context, string messageTemplate, params object[] arguments);
    }
}