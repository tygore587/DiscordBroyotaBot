using DiscordBot.Data.WatchTogether.Models;
using Refit;
using System.Threading.Tasks;

namespace DiscordBot.Data.WatchTogether.DataSources
{
    internal interface IWatchTogetherApi
    {
        const string BaseUrl = "https://api.w2g.tv/";

        [Post("/rooms/create.json")]
        Task<WatchTogetherRoomRemote> CreateRoom([Body] WatchTogetherRoomCreationRequestRemote roomCreationRequest);

        [Post("/rooms/{roomId}/playlists/current/playlist_items/sync_update")]
        Task AddVideoToRoomPlayList(string roomId, [Body] WatchTogetherRoomAddVideosRemote videoAddRequest);
    }
}
