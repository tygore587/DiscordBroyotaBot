namespace DiscordBot.Domain.Dragonball.Entities
{
    public record DragonballCharacter
    (
        string Name,
        string Assist,
        int Color
    )
    {
        public override string ToString()
        {
            return $"{Name} : {Assist}";
        }

        public string ToStringWithColor()
        {
            return $"{ToString()} : {Color}";
        }
    }
}