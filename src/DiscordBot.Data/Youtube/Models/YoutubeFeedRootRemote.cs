using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{

    [XmlRoot(ElementName = "feed")]
	public class YoutubeFeedRootRemote
	{

		[XmlElement(ElementName = "link")]
		public List<LinkRemote> Links { get; set; } = new();

		[XmlElement(ElementName = "id")]
		public string Id { get; set; } = string.Empty;

		[XmlElement(ElementName = "channelId")]
		public string ChannelId { get; set; } = string.Empty;

		[XmlElement(ElementName = "title")]
		public string Title { get; set; } = string.Empty;

		[XmlElement(ElementName = "author")]
		public AuthorRemote? Author { get; set; }

		[XmlElement(ElementName = "published")]
		public DateTime Published { get; set; } = DateTime.UtcNow;

		[XmlElement(ElementName = "entry")]
		public List<VideoInfoRemote> Videos { get; set; } = new();

		[XmlAttribute(AttributeName = "yt")]
		public string XmlNameSpaceYt { get; set; }

		[XmlAttribute(AttributeName = "media")]
		public string XmlNameSpaceMedia { get; set; }

		[XmlAttribute(AttributeName = "xmlns")]
		public string XmlNameSpace { get; set; }
	}
}
