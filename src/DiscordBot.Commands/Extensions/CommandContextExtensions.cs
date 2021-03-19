using DSharpPlus.CommandsNext;

namespace DiscordBot.Commands.Extensions
{
    public static class CommandContextExtensions
    {
        public static string GetAuthorMention(this CommandContext commandContext)
        {
            return commandContext.Message.Author.Mention;
        }
    }
}