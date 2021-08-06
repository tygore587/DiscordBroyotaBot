using System;
using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "entry")]
	public class VideoInfoRemote
	{

		[XmlElement(ElementName = "id")]
		public string Id { get; set; } = string.Empty;

		[XmlElement(ElementName = "videoId")]
		public string VideoId { get; set; } = string.Empty;

		[XmlElement(ElementName = "channelId")]
		public string ChannelId { get; set; } = string.Empty;

		[XmlElement(ElementName = "title")]
		public string Title { get; set; } = string.Empty;

		[XmlElement(ElementName = "link")]
		public LinkRemote Link { get; set; } = string.Empty;

		[XmlElement(ElementName = "author")]
		public AuthorRemote? Author { get; set; }

		[XmlElement(ElementName = "published")]
		public DateTime Published { get; set; } = DateTime.UtcNow;

		[XmlElement(ElementName = "updated")]
		public DateTime Updated { get; set; } = DateTime.UtcNow;

		[XmlElement(ElementName = "group")]
		public VideoMetadataRemote? Metadata { get; set; }
	}
}
