namespace DiscordBot.Domain.WatchTogether.Entities
{
    public class CreatedRoom
    {
        public CreatedRoom(string streamKey)
        {
            StreamKey = streamKey;
        }

        public string StreamKey { get; init; }
    }
}