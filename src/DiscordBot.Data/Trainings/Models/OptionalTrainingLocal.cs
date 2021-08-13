using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Trainings.Models
{
    public record OptionalTrainingLocal(string Name, string Link) : TrainingLocal(Name, Link)
    {
    }
}
