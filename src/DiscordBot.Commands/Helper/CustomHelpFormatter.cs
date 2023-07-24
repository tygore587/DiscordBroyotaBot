using DisCatSharp;
using DisCatSharp.CommandsNext;
using DisCatSharp.CommandsNext.Converters;
using DisCatSharp.CommandsNext.Entities;
using DisCatSharp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable ClassNeverInstantiated.Global

namespace DiscordBot.Commands.Helper
{
    // This is the implementation of the DefaultHelpFormatter. All credits goes to DSharpPlus.
    public class CustomHelpFormatter : BaseHelpFormatter
    {
        public CustomHelpFormatter(CommandContext ctx) : base(ctx)
        {
            EmbedBuilder =
                new DiscordEmbedBuilder()
                    .WithTitle("Help")
                    .WithColor(short.MaxValue);
        }

        private DiscordEmbedBuilder EmbedBuilder { get; }

        private Command? Command { get; set; }

        public override BaseHelpFormatter WithCommand(Command command)
        {
            Command = command;
            EmbedBuilder.WithDescription(Formatter.InlineCode(command.Name) + ": " +
                                         (command.Description ?? "No description provided."));

            if (command is CommandGroup {IsExecutableWithoutSubcommands: true})
                EmbedBuilder.WithDescription(EmbedBuilder.Description +
                                             "\n\nThis group can be executed as a standalone command.");

            var aliases = command.Aliases;
            if ((aliases != null ? aliases.Any() ? 1 : 0 : 0) != 0)
                EmbedBuilder.AddField(new("Aliases",
                    string.Join(", ",
                        command.Aliases.Select(Formatter.InlineCode))));

            var overloads = command.Overloads;
            if ((overloads != null ? overloads.Any() ? 1 : 0 : 0) == 0)
                return this;

            var stringBuilder = new StringBuilder();
            foreach (var commandOverload in command.Overloads
                .OrderByDescending(x => x.Priority))
            {
                stringBuilder.Append('`').Append(command.QualifiedName);
                foreach (var commandArgument in commandOverload.Arguments
                )
                    stringBuilder.Append(commandArgument.IsOptional || commandArgument.IsCatchAll ? " [" : " <")
                        .Append(commandArgument.Name).Append(commandArgument.IsCatchAll ? "..." : "")
                        .Append(commandArgument.IsOptional || commandArgument.IsCatchAll ? ']' : '>');
                stringBuilder.Append("`\n");
                foreach (var commandArgument in commandOverload.Arguments
                )
                    stringBuilder.Append('`').Append(commandArgument.Name).Append(" (")
                        .Append(CommandsNext.GetUserFriendlyTypeName(commandArgument.Type)).Append(")`: ")
                        .Append(commandArgument.Description ?? "No description provided.").Append('\n');
                stringBuilder.Append('\n');
            }

            EmbedBuilder.AddField(new("Arguments", stringBuilder.ToString().Trim()));

            return this;
        }

        public override BaseHelpFormatter WithSubcommands(
            IEnumerable<Command> subcommands)
        {
            string commandFieldName = Command is null ? "Commands" : "Subcommands";

            EmbedBuilder.AddField(new(
                commandFieldName,
                string.Join("\n\n",
                    subcommands.Select(x => $"{Formatter.InlineCode(x.Name)}: {x.Description}"))));

            return this;
        }

        public override CommandHelpMessage Build()
        {
            if (Command is null)
                EmbedBuilder.WithDescription(
                    "Listing all top-level commands and groups.\n Specify a command with **!help <command>** to see more information.");
            return new CommandHelpMessage(embed: EmbedBuilder.Build());
        }
    }
}