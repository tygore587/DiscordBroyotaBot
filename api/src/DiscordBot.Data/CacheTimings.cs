using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data
{
    public static class CacheTimings
    {
        public static readonly TimeSpan Short = TimeSpan.FromSeconds(30);

        public static readonly TimeSpan Normal = TimeSpan.FromMinutes(2);

        public static readonly TimeSpan Long = TimeSpan.FromMinutes(10);
    }
}
