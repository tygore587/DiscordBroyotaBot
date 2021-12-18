using DisCatSharp.ApplicationCommands;
using DisCatSharp.CommandsNext;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DiscordBot.Commands.Logging
{
    public class CommandLogger : ICommandLogger
    {
        private readonly ILogger _logger;

        public CommandLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(CommandContext context, string messageTemplate, params object[] arguments)
        {
            DebugInternal(context.ToLoggingContext(), messageTemplate, arguments);
        }

        public void Error(Exception ex, CommandContext context, string messageTemplate, params object[] arguments)
        {
            ErrorInternal(ex, context.ToLoggingContext(), messageTemplate, arguments);
        }

        public void Information(CommandContext context, string messageTemplate, params object[] arguments)
        {
            InformationInternal(context.ToLoggingContext(), messageTemplate, arguments);
        }

        public void Debug(InteractionContext context, string messageTemplate, params object[] arguments)
        {
            DebugInternal(context.ToLoggingContext(), messageTemplate, arguments);
        }

        public void Error(Exception ex, InteractionContext context, string messageTemplate, params object[] arguments)
        {
            ErrorInternal(ex, context.ToLoggingContext(), messageTemplate, arguments);
        }

        public void Information(InteractionContext context, string messageTemplate, params object[] arguments)
        {
            InformationInternal(context.ToLoggingContext(), messageTemplate, arguments);
        }

        private void DebugInternal(LoggingContext context, string messageTemplate, params object[] arguments)
        {
            Log(LogEventLevel.Debug, context, messageTemplate, arguments);
        }

        private void ErrorInternal(Exception ex, LoggingContext context, string messageTemplate,
            params object[] arguments)
        {
            Log(LogEventLevel.Error, context, messageTemplate, arguments, ex);
        }

        private void InformationInternal(LoggingContext context, string messageTemplate, IEnumerable<object> arguments)
        {
            Log(LogEventLevel.Information, context, messageTemplate, arguments);
        }

        private static (string completeMessageTemplate, List<object> completeArgumentList) AddDiscordContext(
            string messageTemplate, LoggingContext context, IEnumerable<object> argumentList)
        {
            var completeMessageTemplate = messageTemplate;

            var argumentRegex = new Regex("{\\w+}");

            if (argumentRegex.IsMatch(completeMessageTemplate))
                completeMessageTemplate = completeMessageTemplate.Trim() + " |";

            var completeArgumentList = new List<object>(argumentList);

            var (authorId, guildId) = context;

            if (!string.IsNullOrEmpty(guildId))
            {
                completeMessageTemplate += " Guild ID: {guildId} |";
                completeArgumentList.Add(guildId);
            }

            completeMessageTemplate += " Author ID: {author}";
            completeArgumentList.Add(authorId);

            return (completeMessageTemplate, completeArgumentList);
        }

        private void Log(LogEventLevel level, LoggingContext context, string messageTemplate,
            IEnumerable<object> arguments, Exception? ex = null)
        {
            var (completeMessageTemplate, completeArgumentList) =
                AddDiscordContext(messageTemplate, context, arguments);

            if (ex != null)
                _logger.Write(level, ex, completeMessageTemplate, completeArgumentList.ToArray());
            else
                _logger.Write(level, completeMessageTemplate, completeArgumentList.ToArray());
        }
    }
}