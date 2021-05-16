using System.Threading.Tasks;
using DiscordBot.Commands.Extensions;
using DSharpPlus.SlashCommands;

namespace DiscordBot.Commands.Modules.Slash
{
    public class MemeSlashModule : SlashCommandModule
    {
        [SlashCommand("meme", "this returns a random meme from an api.")]
        public async Task OldMemeCommand(InteractionContext context,
            [Option("includeNsfw", "set to true if nsfw content is allowed. Default is false")]
            bool includeNsfw = false)
        {
            await context.RespondWithError(
                "Sorry but the auto completion of discord isn't that great. I decided to rename /meme to /redditmeme. Please use this instead.");
        }
    }
}