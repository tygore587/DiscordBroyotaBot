using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "group", Namespace = "http://search.yahoo.com/mrss/")]
	public class VideoMetaDataRemote
	{

		[XmlElement(ElementName = "title", Namespace = "http://search.yahoo.com/mrss/")]
		public string Title { get; set; } = string.Empty;

		[XmlElement(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
		public PreviewVideoInfoRemote? PreviewVideoInfo { get; set; }

		[XmlElement(ElementName = "thumbnail", Namespace = "http://search.yahoo.com/mrss/")]
		public ThumbnailInfoRemote? Thumbnail { get; set; }

		[XmlElement(ElementName = "description", Namespace = "http://search.yahoo.com/mrss/")]
		public string Description { get; set; } = string.Empty;

		[XmlElement(ElementName = "community", Namespace = "http://search.yahoo.com/mrss/")]
		public CommunityStatisticsRemote? CommunityStatisticsRemote { get; set; }
	}
}
