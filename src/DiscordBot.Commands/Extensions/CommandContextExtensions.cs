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

        public static string? GetGuildId(this CommandContext context)
        {
            return context.Guild?.Id.ToString();
        }
    }
}