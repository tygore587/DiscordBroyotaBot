using DiscordBot.Data.Memes.Models;
using DiscordBot.Domain.Memes.Entities;

namespace DiscordBot.Data.Memes
{
    internal static class MemeExtensions
    {
        public static Meme ToMeme(this MemeRemote memeRemote)
        {
            return new(memeRemote.PostLink, memeRemote.Title, memeRemote.Url, memeRemote.Nsfw);
        }
    }
}