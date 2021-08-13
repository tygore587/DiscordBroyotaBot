using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
	public class PreviewVideoInfoRemote
	{

		[XmlAttribute(AttributeName = "url", Namespace = "")]
		public string Url { get; set; } = string.Empty;

		[XmlAttribute(AttributeName = "type", Namespace = "")]
		public string Type { get; set; } = string.Empty;

		[XmlAttribute(AttributeName = "width", Namespace = "")]
		public int Width { get; set; }

		[XmlAttribute(AttributeName = "height", Namespace = "")]
		public int Height { get; set; }
	}
}
