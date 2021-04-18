using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiscordBot.Data;
using DiscordBot.Data.WatchTogether.Models;
using Refit;

[assembly: InternalsVisibleTo(TestConstants.AssemblyName)]

namespace DiscordBot.Data.WatchTogether.DataSources
{
    internal interface IWatchTogetherApi
    {
        const string BaseUrl = "https://w2g.tv/";

        [Post("/rooms/create.json")]
        Task<WatchTogetherRoomRemote> CreateRoom([Body] WatchTogetherRoomCreationRequestRemote roomCreationRequest);
    }
}