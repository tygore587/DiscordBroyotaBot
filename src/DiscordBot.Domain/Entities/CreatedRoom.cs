namespace DiscordBot.Domain.Entities
{
    public class CreatedRoom
    {
        public CreatedRoom(string streamKey)
        {
            StreamKey = streamKey;
        }

        public string StreamKey { get; }
    }
}