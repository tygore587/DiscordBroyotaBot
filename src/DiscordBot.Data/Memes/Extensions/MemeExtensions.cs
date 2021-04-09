using DiscordBot.Data.Memes.Models;
using DiscordBot.Domain.Memes.Entities;

namespace DiscordBot.Data.Memes.Extensions
{
    internal static class MemeExtensions
    {
        public static Meme ToMeme(this MemeRemote memeRemote)
        {
            return new()
            {
                Nsfw = memeRemote.Nsfw,
                PostLink = memeRemote.PostLink ?? string.Empty,
                Title = memeRemote.Title ?? string.Empty,
                Url = memeRemote.Url ?? string.Empty
            };
        }
    }
}