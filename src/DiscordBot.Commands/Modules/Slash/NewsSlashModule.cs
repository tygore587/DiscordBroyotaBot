﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Domain.News.Entities;
using DiscordBot.Domain.News.UseCases;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace DiscordBot.Commands.Modules.Slash
{
    public class NewsSlashModule : SlashCommandModule
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly GetTagesschauNews _getTagesschauNews;

        private readonly ICommandLogger _logger;

        public NewsSlashModule(IDateTimeProvider dateTimeProvider, GetTagesschauNews getTagesschauNews,
            ICommandLogger logger)
        {
            _dateTimeProvider = dateTimeProvider;
            _getTagesschauNews = getTagesschauNews;
            _logger = logger;
        }

        [SlashCommand("news", "Get news from german official news media (tagesschau.de)")]
        public async Task GetTagesschauNews(InteractionContext context,
            [Option("count", "Number of news you want to get. Default is 5.")]
            long count = 5)
        {
            try
            {
                if (count > EmbeddedConstants.MaxFields)
                {
                    await context.RespondWithError(
                        $"The count must have a maximum of {EmbeddedConstants.MaxFields}. You can't add more fields to an embed.");

                    return;
                }

                await context.SendWorkPendingResponse();

                var parameters = new TagesschauParameters((int) count);

                var news = await _getTagesschauNews.Execute(parameters);

                if (news.Count > EmbeddedConstants.MaxFields)
                    news = news
                        .OrderBy(newsItem => newsItem.PublicationDate)
                        .Take(EmbeddedConstants.MaxFields)
                        .ToList();

                _logger.Information(context, "Successfully processed news command.");

                var embed = BuildNewsEmbed(news);

                await context.SendWorkFinishedResponse(embed);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, context, "Error while processing news command. Count: {count}", count);

                await context.SendWorkFinishedResponse(
                    $"An unexpected error occurs. {ex.Message}");
            }
        }

        private DiscordEmbed BuildNewsEmbed(List<NewsEntity> news)
        {
            var embed = new DiscordEmbedBuilder();

            embed.WithAuthor($"News from {_dateTimeProvider.Today():dd.MM.yyyy}");

            embed.WithUrl("https://www.tagesschau.de");

            embed.WithThumbnail("https://www.appgefahren.de/wp-content/uploads/2016/12/tagesschau-icon.jpg");

            news.ForEach(item => embed.AddField(item.Title,
                $"{item.Description}\n[{item.PublicationDate:dd.MM.yyyy HH:mm}]({item.Link})"));

            return embed.Build();
        }
    }
}