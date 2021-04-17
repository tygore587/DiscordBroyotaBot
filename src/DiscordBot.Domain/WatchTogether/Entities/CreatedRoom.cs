namespace DiscordBot.Domain.WatchTogether.Entities
{
    public record CreatedRoom
    {
        public CreatedRoom(string streamKey)
        {
            StreamKey = streamKey;
        }

        public string StreamKey { get; }
    }
}