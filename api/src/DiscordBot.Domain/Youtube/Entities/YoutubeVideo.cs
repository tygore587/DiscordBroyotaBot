using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Domain.Youtube.Entities
{
    public record YoutubeVideo(string Title, DateTime Published, string Link);
    
}
