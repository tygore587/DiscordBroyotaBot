using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DiscordBot.Commands.Extensions;
using DSharpPlus.CommandsNext;
using Serilog;
using Serilog.Events;

namespace DiscordBot.Commands.Logging
{
    public class CommandLogger : ICommandLogger
    {
        private readonly ILogger _logger;

        public CommandLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Error(Exception ex, CommandContext context, string messageTemplate, params object[] arguments)
        {
            Log(LogEventLevel.Error, context, messageTemplate, arguments);
        }

        public void Information(CommandContext context, string messageTemplate, params object[] arguments)
        {
            Log(LogEventLevel.Information, context, messageTemplate, arguments);
        }

        private static (string completeMessageTemplate, List<object> completeArgumentList) AddDiscordContext(
            string messageTemplate, CommandContext context, IEnumerable<object> argumentList)
        {
            var completeMessageTemplate = messageTemplate;

            var argumentRegex = new Regex("{\\w+}");

            if (argumentRegex.IsMatch(completeMessageTemplate))
                completeMessageTemplate = completeMessageTemplate.Trim() + " |";

            var completeArgumentList = new List<object>(argumentList);

            var guildId = context.GetGuildId();

            if (!string.IsNullOrEmpty(guildId))
            {
                completeMessageTemplate += " Guild: {guildId} |";
                completeArgumentList.Add(guildId);
            }

            completeMessageTemplate += " Author: {author}";
            completeArgumentList.Add(context.GetAuthorId());

            return (completeMessageTemplate, completeArgumentList);
        }

        private void Log(LogEventLevel level, CommandContext context, string messageTemplate, object[] arguments)
        {
            var (completeMessageTemplate, completeArgumentList) =
                AddDiscordContext(messageTemplate, context, arguments);

            _logger.Write(level, completeMessageTemplate, completeArgumentList.ToArray());
        }
    }
}