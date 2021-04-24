using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable UnusedMember.Global

namespace DiscordBot.Commands.Modules.Chat
{
    public class MemeChatModule : BaseCommandModule
    {
        [Command("meme")]
        [Description("This returns a random meme from an api. Use --nsfw to include nfsw content.")]
        public async Task PostRandomMeme(CommandContext context, string argument = "")
        {
            await context.RespondWithDeprecatedMessage("meme");
        }
    }
}