using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "starRating", Namespace = "http://search.yahoo.com/mrss/")]
	public class YoutubeVideoStarRatingRemote
	{

		[XmlAttribute(AttributeName = "count", Namespace = "")]
		public int Count { get; set; }

		[XmlAttribute(AttributeName = "average", Namespace = "")]
		public double Average { get; set; }

		[XmlAttribute(AttributeName = "min", Namespace = "")]
		public int MinRating { get; set; }

		[XmlAttribute(AttributeName = "max", Namespace = "")]
		public int MaxRating { get; set; }
	}
}
