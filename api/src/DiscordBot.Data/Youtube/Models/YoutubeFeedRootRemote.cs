using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{

    [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
	public class YoutubeFeedRootRemote
	{

		[XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
		public List<LinkInfoRemote> LinkInfos { get; set; } = new();

		[XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
		public string Id { get; set; } = string.Empty;

		[XmlElement(ElementName = "channelId", Namespace = "http://www.youtube.com/xml/schemas/2015")]
		public string ChannelId { get; set; } = string.Empty;

		[XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
		public string Title { get; set; } = string.Empty;

		[XmlElement(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
		public AuthorRemote? Author { get; set; }

		[XmlElement(ElementName = "published", Namespace = "http://www.w3.org/2005/Atom")]
		public DateTime Published { get; set; } = DateTime.UtcNow;

		[XmlElement(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
		public List<YoutubeVideoInfoRemote> YoutubeVideos { get; set; } = new();

		[XmlAttribute(AttributeName = "yt", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string YoutubeXmlNamespace { get; set; } = string.Empty;

		[XmlAttribute(AttributeName = "media", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string MediaNamespace { get; set; } = string.Empty;

		[XmlAttribute(AttributeName = "xmlns", Namespace = "")]
		public string XmlNamespace { get; set; } = string.Empty;
	}
}
