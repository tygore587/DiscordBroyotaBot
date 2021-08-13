using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "statistics", Namespace = "http://search.yahoo.com/mrss/")]
	public class VideoStatisticsRemote
	{

		[XmlAttribute(AttributeName = "views", Namespace = "")]
		public int Views { get; set; }
	}
}
