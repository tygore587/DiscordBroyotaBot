using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "community", Namespace = "http://search.yahoo.com/mrss/")]
	public class CommunityStatisticsRemote
	{

		[XmlElement(ElementName = "starRating", Namespace = "http://search.yahoo.com/mrss/")]
		public YoutubeVideoStarRatingRemote? StarRating { get; set; }

		[XmlElement(ElementName = "statistics", Namespace = "http://search.yahoo.com/mrss/")]
		public VideoStatisticsRemote? VideoStatictics { get; set; }
	}
}
