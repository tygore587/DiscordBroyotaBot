using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "community")]
	public class VideoCommunityStatisticsRemote
	{

		[XmlElement(ElementName = "starRating")]
		public VideoStarRatingRemote StarRating { get; set; } = new();

		[XmlElement(ElementName = "statistics")]
		public VideoStatisticsRemote Statistics { get; set; } = new();
	}
}
