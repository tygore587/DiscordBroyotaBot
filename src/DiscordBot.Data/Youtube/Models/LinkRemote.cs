using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "link")]
	public class LinkRemote
	{

		[XmlAttribute(AttributeName = "rel")]
		public string Relation { get; set; } = string.Empty; // can be self or alternate

		[XmlAttribute(AttributeName = "href")]
		public string Link { get; set; } = string.Empty; // link to rss feed on self and channel on alternate
	}
}
