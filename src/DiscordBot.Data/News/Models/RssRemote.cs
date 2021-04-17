using System.Xml.Serialization;

namespace DiscordBot.Data.News.Models
{
    [XmlRoot(ElementName = "rss")]
    public class RssRemote
    {
        [XmlElement(ElementName = "channel")]
        public ChannelRemote Channel { get; set; } = new();

        [XmlAttribute(AttributeName = "content", Namespace = "https://www.w3.org/2000/xmlns/")]
        public string? Content { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string? Version { get; set; }
    }
}