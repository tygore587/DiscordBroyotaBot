using System;

namespace DiscordBot.Domain.News.Entities
{
    public record NewsInternal
    (
        string Title,
        string Link,
        string Description,
        DateTime PublicationDate
    );
}