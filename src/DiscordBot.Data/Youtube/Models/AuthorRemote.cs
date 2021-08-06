using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "author")]
	public class AuthorRemote
	{

		[XmlElement(ElementName = "name")]
		public string Name { get; set; } = string.Empty;

		[XmlElement(ElementName = "uri")]
		public string Uri { get; set; } = string.Empty;
	}
}
