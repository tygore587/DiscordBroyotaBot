namespace DiscordBot.Domain.Dragonball.Models
{
    public class DragonballCharacter
    {
        public string Name { get; }
        public string Assist { get; }
        public int Color { get; }

        public DragonballCharacter(string name, string assist, int color)
        {
            Name = name;
            Assist = assist;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Name} : {Assist}";
        }

        public string ToStringWithColor() => $"{ToString()} : {Color}";
    }
}