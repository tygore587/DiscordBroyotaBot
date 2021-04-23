using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace DiscordBot.Commands.Extensions
{
    public static class InteractionContextExtensions
    {
        public static string GetGuildId(this InteractionContext context)
        {
            return context.Guild.Id.ToString();
        }

        public static string GetAuthorId(this InteractionContext context)
        {
            return context.Member.Id.ToString();
        }

        public static Task RespondImmediate(this InteractionContext context, string message)
        {
            var builder = new DiscordInteractionResponseBuilder().WithContent(message);

            return context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, builder);
        }
    }
}