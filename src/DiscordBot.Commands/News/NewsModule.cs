using System;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DiscordBot.Domain.News.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

// ReSharper disable UnusedMember.Global

namespace DiscordBot.Commands.News
{
    public class NewsModule : BaseCommandModule
    {
        private readonly GetTagesschauNews _getTagesschauNews;

        public NewsModule(GetTagesschauNews getTagesschauNews)
        {
            _getTagesschauNews = getTagesschauNews;
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
                var parameters = new TagesschauParameters(count);

                var news = await _getTagesschauNews.Execute(parameters);

                if (news.Count > EmbeddedConstants.MaxFields)
                    news = news
                        .OrderBy(newsItem => newsItem.PublicationDate)
                        .Take(EmbeddedConstants.MaxFields)
                        .ToList();

                var embed = new DiscordEmbedBuilder();

                embed.WithAuthor($"News from {DateTime.Today:dd.MM.yyyy}");

                embed.WithUrl("https://www.tagesschau.de");

                embed.WithThumbnail("https://www.appgefahren.de/wp-content/uploads/2016/12/tagesschau-icon.jpg");

                news.ForEach(item => embed.AddField(item.Title,
                    $"{item.Description}\n[{item.PublicationDate:dd.MM.yyyy HH:mm}]({item.Link})"));

                await context.RespondAsync(embed: embed.Build());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await context.RespondAsync($"{context.GetAuthorMention()} An unexpected error occurs. {ex.Message}");
            }
        }
    }
}