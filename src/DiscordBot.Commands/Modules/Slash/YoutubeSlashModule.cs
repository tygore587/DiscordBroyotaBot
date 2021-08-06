using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Modules.Slash
{
    [SlashCommandGroup("youtube", "Get video from youtube")]
    public class YoutubeSlashModule : SlashCommandModule
    {
        private ICommandLogger _logger;

        public YoutubeSlashModule(ICommandLogger logger)
        {
            _logger = logger;
        }

        [SlashCommand("tagesschau", "Get the current tagesschau links.")]
        public async Task GetCurrentTagesschau(InteractionContext context)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex, context, "Error while processing news command.");

                await context.SendWorkFinishedResponse(
                    $"An unexpected error occurs. {ex.Message}");
            }
        }
    }
}
