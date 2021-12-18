using System;
using System.Collections.Generic;
using System.Linq;
using DiscordBot.Data.News.Models;
using DiscordBot.Domain.News.Entities;

namespace DiscordBot.Data.News
{
    public static class NewsExtensions
    {
        private static NewsEntity ToNewsInternal(this ItemRemote itemRemote)
        {
            return new(
                itemRemote.Title,
                itemRemote.Link,
                itemRemote.Description,
                DateTime.Parse(itemRemote.PublicationDate)
            );
        }

        private static IEnumerable<NewsEntity> ToNewsInternalList(this IEnumerable<ItemRemote> itemRemotes)
        {
            return itemRemotes.Select(item => item.ToNewsInternal());
        }

        public static IEnumerable<NewsEntity> ToNewsInternalList(this RssRemote rssRemote)
        {
            return rssRemote.Channel.Items.ToNewsInternalList();
        }
    }
}