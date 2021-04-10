namespace DiscordBot.Domain.Entities
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
        private string Assist { get; }
        private int Color { get; }

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