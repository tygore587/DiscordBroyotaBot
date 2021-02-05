namespace DiscordBot.Dragonball.Domain.Models
{
    public class DragonballCharacter
    {
        public DragonballCharacter(string name, string assist, int color)
        {
            Name = name;
            Assist = assist;
            Color = color;
        }

        public string Name { get; }
        public string Assist { get; }
        public int Color { get; }

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