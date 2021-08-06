using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "starRating")]
	public class VideoStarRatingRemote
	{

		[XmlAttribute(AttributeName = "count")]
		public int Count { get; set; } = 0;

		[XmlAttribute(AttributeName = "average")]
		public double Average { get; set; } = 0.0;

		[XmlAttribute(AttributeName = "min")]
		public int Min { get; set; } = 0;

		[XmlAttribute(AttributeName = "max")]
		public int Max { get; set; } = int.MaxValue;
	}
}
