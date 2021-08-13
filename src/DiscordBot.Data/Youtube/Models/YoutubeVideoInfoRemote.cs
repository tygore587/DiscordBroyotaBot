using System;
using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
	public class YoutubeVideoInfoRemote
	{

		[XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
		public string Id { get; set; } = string.Empty;

		[XmlElement(ElementName = "videoId", Namespace = "http://www.youtube.com/xml/schemas/2015")]
		public string VideoId { get; set; } = string.Empty;

		[XmlElement(ElementName = "channelId", Namespace = "http://www.youtube.com/xml/schemas/2015")]
		public string ChannelId { get; set; } = string.Empty;

		[XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
		public string Title { get; set; } = string.Empty;

		[XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
		public LinkInfoRemote? LinkInfo { get; set; }

		[XmlElement(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
		public AuthorRemote? Author { get; set; }

		[XmlElement(ElementName = "published", Namespace = "http://www.w3.org/2005/Atom")]
		public DateTime Published { get; set; } = DateTime.Now;

		[XmlElement(ElementName = "updated", Namespace = "http://www.w3.org/2005/Atom")]
		public DateTime Updated { get; set; } = DateTime.Now;

		[XmlElement(ElementName = "group", Namespace = "http://search.yahoo.com/mrss/")]
		public VideoMetaDataRemote? VideoMetaData { get; set; }
	}
}
