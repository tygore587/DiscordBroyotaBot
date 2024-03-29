﻿using DisCatSharp.ApplicationCommands.Context;
using DisCatSharp.Entities;
using DisCatSharp.Enums;
using System.Threading.Tasks;

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
            var response = new DiscordInteractionResponseBuilder().WithContent(errorMessage).AsEphemeral();

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

        public static Task SendWorkFinishedResponse(this InteractionContext context, DiscordEmbed embed,
            string? message = null)
        {
            var response = new DiscordWebhookBuilder().AddEmbed(embed);

            if (!string.IsNullOrWhiteSpace(message))
                response.WithContent(message);

            return context.EditResponseAsync(response);
        }
    }
}