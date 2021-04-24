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

        public static string GetAuthorMention(this InteractionContext context)
        {
            return context.Member.Mention;
        }

        public static Task RespondImmediate(this InteractionContext context, string message)
        {
            var response = new DiscordInteractionResponseBuilder().WithContent(message);

            return context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, response);
        }

        public static Task RespondWithError(this InteractionContext context, string errorMessage)
        {
            var response = new DiscordInteractionResponseBuilder().WithContent(errorMessage).AsEphemeral(true);

            return context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, response);
        }

        public static Task SendWorkPendingResponse(this InteractionContext context)
        {
            return context.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
        }

        public static Task SendWorkFinishedResponse(this InteractionContext context, string message)
        {
            var response = new DiscordWebhookBuilder().WithContent(message);

            return context.EditResponseAsync(response);
        }

        public static Task SendWorkFinishedResponse(this InteractionContext context, string message, DiscordEmbed embed)
        {
            var response = new DiscordWebhookBuilder().WithContent(message).AddEmbed(embed);

            return context.EditResponseAsync(response);
        }
    }
}