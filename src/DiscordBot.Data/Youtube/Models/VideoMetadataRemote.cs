using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "group")]
	public class VideoMetadataRemote
	{

		[XmlElement(ElementName = "title")]
		public string Title { get; set; } = string.Empty;

		[XmlElement(ElementName = "content")]
		public VideoThumbnailHoverVideoInfoRemote? Content { get; set; }

		[XmlElement(ElementName = "thumbnail")]
		public VideoThumbnailInfoRemote? Thumbnail { get; set; }

		[XmlElement(ElementName = "description")]
		public string VideoDescription { get; set; } = string.Empty;

		[XmlElement(ElementName = "community")]
		public VideoCommunityStatisticsRemote CommunityStatistics { get; set; } = new();
	}
}
