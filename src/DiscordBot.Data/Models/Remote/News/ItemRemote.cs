using System.Xml.Serialization;

namespace DiscordBot.Data.Models.Remote.News
{
    [XmlRoot(ElementName = "item")]
    public class ItemRemote
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; } = string.Empty;

        [XmlElement(ElementName = "link")]
        public string Link { get; set; } = string.Empty;

        [XmlElement(ElementName = "pubDate")]
        public string PublicationDate { get; set; } = string.Empty;

        [XmlElement(ElementName = "description")]
        public string Description { get; set; } = string.Empty;

        [XmlElement(ElementName = "guid")]
        public string Id { get; set; } = string.Empty;

        [XmlElement(ElementName = "encoded", Namespace = "http://purl.org/rss/1.0/modules/content/")]
        public string Encoded { get; set; } = string.Empty;
    }
}