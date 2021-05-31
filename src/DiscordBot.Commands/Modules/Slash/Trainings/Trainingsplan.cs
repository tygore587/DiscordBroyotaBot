using DSharpPlus.SlashCommands;

namespace DiscordBot.Commands.Modules.Slash.Trainings
{
    public enum Trainingsplan
    {
        [ChoiceName("Igor from 0 to 100")] IgorFrom0To100,

        [ChoiceName("Sascha Huber Plan 1 Anfang")]
        SaschaHuberPlan1Starter
    }
}