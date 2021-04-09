using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiscordBot.Data.WatchTogether.Models;
using Refit;

[assembly: InternalsVisibleTo("DiscordBot.Data.Tests.Unit")]

namespace DiscordBot.Data.WatchTogether.DataSources
{
    internal interface IWatchTogetherApi
    {
        public static readonly string BaseUrl = "https://w2g.tv/";

        [Post("/rooms/create.json")]
        Task<WatchTogetherRoomRemote> CreateRoom([Body] WatchTogetherRoomCreationRequestRemote roomCreationRequest);
    }
}