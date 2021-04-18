using System;
using Newtonsoft.Json;

namespace DiscordBot.Data.WatchTogether.Models
{
    [JsonObject]
    public record WatchTogetherRoomRemote
    (
        [JsonProperty("streamkey")] string StreamKey,
        [JsonProperty("id")] int Id,
        [JsonProperty("created_at")] DateTime CreatedAt,
        [JsonProperty("persistent")] bool Persistent,
        [JsonProperty("persistent_name")] object? PersistentName,
        [JsonProperty("deleted")] bool Deleted,
        [JsonProperty("moderated")] bool Moderated,
        [JsonProperty("location")] string? Location,
        [JsonProperty("stream_created")] bool StreamCreated,
        [JsonProperty("background")] object? Background,
        [JsonProperty("moderated_background")] bool ModeratedBackground,
        [JsonProperty("moderated_playlist")] bool ModeratedPlaylist,
        [JsonProperty("bg_color")] string? BgColor,
        [JsonProperty("bg_opacity")] double BgOpacity,
        [JsonProperty("moderated_item")] bool ModeratedItem,
        [JsonProperty("theme_bg")] object? ThemeBg,
        [JsonProperty("playlist_id")] int PlaylistId,
        [JsonProperty("members_only")] bool MembersOnly,
        [JsonProperty("moderated_suggestions")]
        bool ModeratedSuggestions,
        [JsonProperty("moderated_chat")] bool ModeratedChat,
        [JsonProperty("moderated_user")] bool ModeratedUser,
        [JsonProperty("moderated_cam")] bool ModeratedCam
    );
}