using DisCatSharp.CommandsNext;
using DisCatSharp.CommandsNext.Attributes;
using DiscordBot.Commands.Extensions;
using System.Threading.Tasks;

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