using DiscordBot.Domain.Dragonball.Entities;

namespace DiscordBot.Api.Models.Dragonballs
{
    public static class DragonnballExtensions
    {

        public static List<DragonballCharacterResponse> ToDragonballCharacterResponseList(this IEnumerable<DragonballCharacter> characters)
        {
            return characters.Select(ToDragonballCharacterResponse).ToList();
        }
        private static DragonballCharacterResponse ToDragonballCharacterResponse(this DragonballCharacter character)
        {
            return new DragonballCharacterResponse
            {
                Assist = character.Assist,
                Color = character.Color,
                Name = character.Name,
            };
        }
    }
}
