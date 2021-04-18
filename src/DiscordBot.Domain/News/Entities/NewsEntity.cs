using System;

namespace DiscordBot.Domain.News.Entities
{
    public record NewsEntity
    (
        string Title,
        string Link,
        string Description,
        DateTime PublicationDate
    );
}