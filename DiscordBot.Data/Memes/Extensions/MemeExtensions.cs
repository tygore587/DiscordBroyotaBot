using DiscordBot.Data.Memes.Models;
using DiscordBot.Domain.Memes.Entities;

namespace DiscordBot.Data.Memes.Extensions
{
    internal static class MemeExtensions
    {
        public static Meme ToMeme(this MemeRemote memeRemote)
        {
            return memeRemote == null
                ? null
                : new Meme
                {
                    Author = memeRemote.Author,
                    Nsfw = memeRemote.Nsfw,
                    PostLink = memeRemote.PostLink,
                    Preview = memeRemote.Preview,
                    Spoiler = memeRemote.Spoiler,
                    Subreddit = memeRemote.Subreddit,
                    Title = memeRemote.Title,
                    Ups = memeRemote.Ups,
                    Url = memeRemote.Url
                };
        }
    }
}