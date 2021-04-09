using System;
using System.Collections.Generic;
using System.Linq;
using DiscordBot.Data.News.Models;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Data.News.Extensions
{
    public static class NewsExtensions
    {
        private static NewsInternal ToNewsInternal(this ItemRemote itemRemote)
        {
            return new(
                itemRemote.Title,
                itemRemote.Link,
                itemRemote.Description,
                DateTime.Parse(itemRemote.PublicationDate)
            );
        }

        private static IEnumerable<NewsInternal> ToNewsInternalList(this IEnumerable<ItemRemote> itemRemotes)
        {
            return itemRemotes.Select(item => item.ToNewsInternal());
        }

        public static IEnumerable<NewsInternal> ToNewsInternalList(this RssRemote rssRemote)
        {
            return rssRemote.Channel.Items.ToNewsInternalList();
        }
    }
}