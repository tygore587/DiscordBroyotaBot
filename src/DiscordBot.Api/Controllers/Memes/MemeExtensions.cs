using DiscordBot.Api.Models.Memes;
using DiscordBot.Domain.Memes.Entities;

namespace DiscordBot.Api.Controllers.Memes
{
    public static class MemeExtensions
    {
        public static MemeResponse ToMemeResponse(this Meme meme)
        {
            return new MemeResponse
            {
                Nsfw = meme.Nsfw,
                PostLink = meme.PostLink,
                Title = meme.Title,
                Url = meme.Url,
            };
        }
    }
}
