using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable UnusedMember.Global

namespace DiscordBot.Commands.Modules.Chat
{
    [Description("All dices commands.")]
    public class DiceChatModule : BaseCommandModule
    {
        [Command("roll")]
        [Description("This rolls a die with sides.")]
        [RequireGuild]
        public async Task RollDie(CommandContext context, [Description("Number of sides")] int sides = 20)
        {
            await context.RespondWithDeprecatedMessage("roll");
        }
    }
}