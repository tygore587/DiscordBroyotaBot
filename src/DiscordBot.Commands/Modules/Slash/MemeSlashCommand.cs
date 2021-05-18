using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DSharpPlus.SlashCommands;

namespace DiscordBot.Commands.Modules.Slash
{
    public class MemeSlashModule : SlashCommandModule
    {
        [SlashCommand("meme", "this command is obsolete. Use /redditmeme")]
        public async Task OldMemeCommand(InteractionContext context,
            [Option("includeNsfw", "this is obsolete")]
            bool includeNsfw = false)
        {
            await context.RespondWithError(
                "Sorry but the auto completion of discord isn't that great. I decided to rename /meme to /redditmeme. Please use this instead.");
        }
    }
}