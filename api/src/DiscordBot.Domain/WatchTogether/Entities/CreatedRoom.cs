namespace DiscordBot.Domain.WatchTogether.Entities
{
    public record CreatedRoom
    (
        string RoomId
    )
    {
        private const string WatchTogetherBaseUrl = "https://w2g.tv/rooms";

        public string RoomLink => $"{WatchTogetherBaseUrl}/{RoomId}";
    }
}