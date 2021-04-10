using DiscordBot.Data.Models.Remote;
using DiscordBot.Domain.Entities;

namespace DiscordBot.Data.Extensions
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