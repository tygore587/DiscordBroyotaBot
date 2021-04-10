using System;
using Newtonsoft.Json;

namespace DiscordBot.Data.Models.Remote.WatchTogether
{
    [JsonObject]
    public class WatchTogetherRoomRemote
    {
        [JsonProperty("streamkey")]
        public string StreamKey = "";

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("persistent")]
        public bool Persistent { get; set; }

        [JsonProperty("persistent_name")]
        public object? PersistentName { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("moderated")]
        public bool Moderated { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("stream_created")]
        public bool StreamCreated { get; set; }

        [JsonProperty("background")]
        public object? Background { get; set; }

        [JsonProperty("moderated_background")]
        public bool ModeratedBackground { get; set; }

        [JsonProperty("moderated_playlist")]
        public bool ModeratedPlaylist { get; set; }

        [JsonProperty("bg_color")]
        public string? BgColor { get; set; }

        [JsonProperty("bg_opacity")]
        public double BgOpacity { get; set; }

        [JsonProperty("moderated_item")]
        public bool ModeratedItem { get; set; }

        [JsonProperty("theme_bg")]
        public object? ThemeBg { get; set; }

        [JsonProperty("playlist_id")]
        public int PlaylistId { get; set; }

        [JsonProperty("members_only")]
        public bool MembersOnly { get; set; }

        [JsonProperty("moderated_suggestions")]
        public bool ModeratedSuggestions { get; set; }

        [JsonProperty("moderated_chat")]
        public bool ModeratedChat { get; set; }

        [JsonProperty("moderated_user")]
        public bool ModeratedUser { get; set; }

        [JsonProperty("moderated_cam")]
        public bool ModeratedCam { get; set; }
    }
}