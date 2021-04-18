using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Core.DateTimeProvider;
using DiscordBot.Domain.News.Entities;
using DiscordBot.Domain.News.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

// ReSharper disable UnusedMember.Global

namespace DiscordBot.Commands.Modules
{
    public class NewsModule : BaseCommandModule
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly GetTagesschauNews _getTagesschauNews;

        private readonly ICommandLogger _logger;

        public NewsModule(GetTagesschauNews getTagesschauNews, ICommandLogger logger,
            IDateTimeProvider dateTimeProvider)
        {
            _getTagesschauNews = getTagesschauNews;
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
        }

        [Command("news")]
        [Aliases("tagesschau")]
        [Description("Get news from german official news media.")]
        public async Task GetTagesschauNews(CommandContext context,
            [Description("Number of news in a card. Defaults to 5")]
            int count = 5)
        {
            try
            {
                await context.TriggerTypingAsync();

                var parameters = new TagesschauParameters(count);

                var news = await _getTagesschauNews.Execute(parameters);

                if (news.Count > EmbeddedConstants.MaxFields)
                    news = news
                        .OrderBy(newsItem => newsItem.PublicationDate)
                        .Take(EmbeddedConstants.MaxFields)
                        .ToList();

                _logger.Information(context, "Successfully processed news command.");

                var embed = BuildNewsEmbed(news);

                await context.RespondAsync(embed: embed);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, context, "Error while processing news command. Count: {count}", count);

                await context.RespondAsync($"{context.GetAuthorMention()} An unexpected error occurs. {ex.Message}");
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