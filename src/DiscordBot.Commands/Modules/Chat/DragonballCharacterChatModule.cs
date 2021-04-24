using System.Threading.Tasks;
using DiscordBot.Commands.Exceptions;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace DiscordBot.Commands.Modules.Chat
{
    public class DragonballCharacterChatModule : BaseCommandModule
    {
        private readonly ICommandLogger _logger;

        public DragonballCharacterChatModule(ICommandLogger logger)
        {
            _logger = logger;
        }


        [Command("dbzRandom")]
        [Description(
            "This returns 3 random characters with assists for the game Dragonball FighterZ. If you want to have random colors, please add --colors as an argument.")]
        [RequireGuild]
        public async Task GetRandomCharacterChoice(CommandContext context,
            [Description("Use --color to also get random color.")]
            string argument = "")
        {
            try
            {
                await context.RespondWithDeprecatedMessage("dbz random");
            }
            catch (ArgumentValidationException ex)
            {
                _logger.Error(ex, context, "Error while processing dragonball command.");

                await context.RespondAsync($"{context.GetAuthorMention()} {ex.Message}");
            }
        }
    }
}