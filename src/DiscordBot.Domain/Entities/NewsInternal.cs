using System;

namespace DiscordBot.Domain.Entities
{
    public class NewsInternal
    {
        public NewsInternal(string title, string link, string description, DateTime publicationDate)
        {
            Title = title;
            Link = link;
            Description = description;
            PublicationDate = publicationDate;
        }

        public string Title { get; }

        public string Link { get; }

        public string Description { get; }

        public DateTime PublicationDate { get; }
    }
}