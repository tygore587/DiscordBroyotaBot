using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;

namespace DiscordBot.Commands.Logging
{
    public interface ICommandLogger
    {
        void Error(Exception ex, CommandContext context, string messageTemplate, params object[] arguments);
        void Information(CommandContext context, string messageTemplate, params object[] arguments);
        void Debug(CommandContext context, string messageTemplate, params object[] arguments);
        void Debug(InteractionContext context, string messageTemplate, params object[] arguments);
        void Error(Exception ex, InteractionContext context, string messageTemplate, params object[] arguments);
        void Information(InteractionContext context, string messageTemplate, params object[] arguments);
    }
}