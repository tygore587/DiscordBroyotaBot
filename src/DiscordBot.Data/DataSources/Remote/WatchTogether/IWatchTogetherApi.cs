using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiscordBot.Data;
using DiscordBot.Data.Models.Remote.WatchTogether;
using Refit;

[assembly: InternalsVisibleTo(TestConstants.AssemblyName)]

namespace DiscordBot.Data.DataSources.Remote.WatchTogether
{
    internal interface IWatchTogetherApi
    {
        const string BaseUrl = "https://w2g.tv/";

        [Post("/rooms/create.json")]
        Task<WatchTogetherRoomRemote> CreateRoom([Body] WatchTogetherRoomCreationRequestRemote roomCreationRequest);
    }
}