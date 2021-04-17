using AutoFixture;
using DiscordBot.Data.Memes;
using DiscordBot.Data.Memes.Models;
using DiscordBot.Domain.Memes.Entities;
using FluentAssertions;
using Xunit;

namespace DiscordBot.Data.Tests.Unit.Memes
{
    public class MemeExtensionsTests
    {
        [Fact]
        public void MemeRemoteShouldConvertToMemeCorrectly()
        {
            var fixture = new Fixture();

            var memeRemote = fixture.Create<MemeRemote>();

            var expectedMeme = new Meme
            {
                Nsfw = memeRemote.Nsfw,
                Title = memeRemote.Title,
                Url = memeRemote.Url,
                PostLink = memeRemote.PostLink
            };

            var actualMeme = memeRemote.ToMeme();

            actualMeme.Should().BeEquivalentTo(expectedMeme);
        }
    }
}