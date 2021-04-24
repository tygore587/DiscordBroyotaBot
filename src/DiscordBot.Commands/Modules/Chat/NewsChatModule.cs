using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable UnusedMember.Global

namespace DiscordBot.Commands.Modules.Chat
{
    public class NewsChatModule : BaseCommandModule
    {
        [Command("news")]
        [Aliases("tagesschau")]
        [Description("Get news from german official news media.")]
        public async Task GetTagesschauNews(CommandContext context,
            [Description("Number of news in a card. Defaults to 5")]
            int count = 5)
        {
            await context.RespondWithDeprecatedMessage("news");
        }
    }
}