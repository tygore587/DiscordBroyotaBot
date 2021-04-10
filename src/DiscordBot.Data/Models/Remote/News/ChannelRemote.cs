using System.Collections.Generic;
using System.Xml.Serialization;

namespace DiscordBot.Data.Models.Remote.News
{
    [XmlRoot(ElementName = "channel")]
    public class ChannelRemote
    {
        [XmlElement(ElementName = "title")]
        public string? Title { get; set; }

        [XmlElement(ElementName = "link")]
        public string? Link { get; set; }

        [XmlElement(ElementName = "description")]
        public string? Description { get; set; }

        [XmlElement(ElementName = "language")]
        public string? Language { get; set; }

        [XmlElement(ElementName = "copyright")]
        public string? Copyright { get; set; }

        [XmlElement(ElementName = "lastBuildDate")]
        public string? LastBuildDate { get; set; }

        [XmlElement(ElementName = "docs")]
        public string? Docs { get; set; }

        [XmlElement(ElementName = "ttl")]
        public string? TimeToLife { get; set; }

        [XmlElement(ElementName = "item")]
        public List<ItemRemote> Items { get; set; } = new();
    }
}