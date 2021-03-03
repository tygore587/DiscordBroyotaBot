using Discordbot.Memes.Domain.Entities;
using DiscordBot.Memes.Data.Models;

namespace DiscordBot.Memes.Data.Extensions
{
    internal static class MemeExtensions
    {
        public static Meme ToMeme(this MemeRemote memeRemote) =>
            memeRemote == null
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
                    Url = memeRemote.Url,
                };
    }
}