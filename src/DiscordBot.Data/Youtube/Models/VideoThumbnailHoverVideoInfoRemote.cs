using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "content")]
	public class VideoThumbnailHoverVideoInfoRemote
	{

		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; } = string.Empty;

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; } = string.Empty;

		[XmlAttribute(AttributeName = "width")]
		public int Width { get; set; } = 0;

		[XmlAttribute(AttributeName = "height")]
		public int Height { get; set; } = 0;
	}
}
