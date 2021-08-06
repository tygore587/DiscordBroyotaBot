using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "statistics")]
	public class VideoStatisticsRemote
	{

		[XmlAttribute(AttributeName = "views")]
		public int Views { get; set; } = 0;
	}
}
