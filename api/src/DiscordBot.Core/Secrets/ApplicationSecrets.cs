﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Core.Secrets
{
    public record ApplicationSecrets(string FirebaseProjectId, string WatchTogetherApiKey);
}
