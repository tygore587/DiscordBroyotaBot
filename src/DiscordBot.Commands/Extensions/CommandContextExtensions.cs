using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace DiscordBot.Commands.Extensions
{
    public static class CommandContextExtensions
    {
        public static string GetAuthorMention(this CommandContext commandContext)
        {
            return commandContext.Message.Author.Mention;
        }

        public static string GetAuthorId(this CommandContext context)
        {
            return context.Message.Author.Id.ToString();
        }

        public static string GetGuildId(this CommandContext context)
        {
            return context.Guild?.Id.ToString() ?? string.Empty;
        }

        public static Task RespondWithDeprecatedMessage(this CommandContext context, string slashCommand)
        {
            return context.RespondAsync(
                $"{context.GetAuthorMention()} the command {context.Command.Name} is deprecated. Please use the `/{slashCommand}` slash command.");
        }
    }
}