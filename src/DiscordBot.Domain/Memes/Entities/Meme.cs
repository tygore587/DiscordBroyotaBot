using System.Collections.Generic;

namespace DiscordBot.Domain.Memes.Entities
{
    public class Meme
    {
        public string PostLink { get; set; }
        public string Subreddit { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool Nsfw { get; set; }
        public bool Spoiler { get; set; }
        public string Author { get; set; }
        public int Ups { get; set; }
        public List<string> Preview { get; set; }
    }
}