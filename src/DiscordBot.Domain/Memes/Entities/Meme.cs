namespace DiscordBot.Domain.Memes.Entities
{
    public record Meme
    (
        string PostLink,
        string Title,
        string Url,
        bool Nsfw
    );
}