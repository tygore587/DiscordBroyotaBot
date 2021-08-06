using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "thumbnail")]
	public class VideoThumbnailInfoRemote
	{

		[XmlAttribute(AttributeName = "url")]
		public string Url { get; set; } = string.Empty;

		[XmlAttribute(AttributeName = "width")]
		public int Width { get; set; } = 0;

		[XmlAttribute(AttributeName = "height")]
		public int Height { get; set; } = 0;
	}
}
