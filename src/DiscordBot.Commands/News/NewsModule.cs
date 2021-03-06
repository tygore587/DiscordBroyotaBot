using System.Threading.Tasks;
using DiscordBot.Domain.News.UseCases;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

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
        [Description("")]
        public async Task GetTagesschauNews(CommandContext context, int count = 1)
        {
            var parameters = new TagesschauParameters(1);

            var test = await _getTagesschauNews.Execute(parameters);

            await context.RespondAsync("Was ok");
        }
    }
}