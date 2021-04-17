namespace DiscordBot.Domain.Memes.Entities
{
    public record Meme
    {
        public string PostLink { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;
        public bool Nsfw { get; init; }
    }
}