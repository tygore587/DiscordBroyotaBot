﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Commands.Exceptions;
using DiscordBot.Commands.Extensions;
using DiscordBot.Commands.Logging;
using DiscordBot.Domain.Dragonball.Entities;
using DiscordBot.Domain.Dragonball.UseCases;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace DiscordBot.Commands.Modules.Slash
{
    public class DragonballSlashModule : SlashCommandModule
    {
        [SlashCommandGroup("dbz", "Holds all dragonball commands.")]
        public class DragonballFighterZModule
        {
            private readonly GetRandomCharacters _getRandomCharacters;
            private readonly ICommandLogger _logger;

            public DragonballFighterZModule(GetRandomCharacters getRandomCharacters, ICommandLogger logger)
            {
                _getRandomCharacters = getRandomCharacters;
                _logger = logger;
            }

            [SlashCommand("random", "Returns 3 random characters with assists for the game Dragonball FighterZ.")]
            public async Task GetRandomCharacterChoice(InteractionContext context,
                [Option("includeColors", "Choose if you want to ")]
                bool withColors = false)
            {
                try
                {
                    await context.SendWorkPendingResponse();

                    var characterParams = new RandomCharacterParams
                    {
                        Count = 3
                    };

                    var characters = _getRandomCharacters.Execute(characterParams);

                    _logger.Information(context, "Successfully got dragonball characters. {@characters}", characters);

                    var embed = CreateRandomCharacterEmbed(characters, withColors);

                    await context.SendWorkFinishedResponse(embed, "The bot has chosen:");
                }
                catch (ArgumentValidationException ex)
                {
                    _logger.Error(ex, context, "Error while processing dragonball command.");

                    await context.SendWorkFinishedResponse($"{context.GetAuthorMention()} {ex.Message}");
                }
            }

            private static DiscordEmbed CreateRandomCharacterEmbed(List<DragonballCharacter> dragonballCharacters,
                bool withColor)
            {
                var embedBuilder = new DiscordEmbedBuilder();

                embedBuilder.WithAuthor("Random Characters");

                embedBuilder.WithThumbnail(
                    "https://cdn.akamai.steamstatic.com/steam/apps/678950/header.jpg?t=1617120109");

                dragonballCharacters.ForEach(character =>
                {
                    var (name,
                        assist,
                        color) = character;

                    var text = $"Assist: {assist}";

                    if (withColor)
                        text += $"\nColor: {color}";

                    embedBuilder.AddField(name, text);
                });

                return embedBuilder.Build();
            }
        }
    }
}