using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    [XmlRoot(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
	public class AuthorRemote
	{

		[XmlElement(ElementName = "name", Namespace = "http://www.w3.org/2005/Atom")]
		public string Name { get; set; } = string.Empty;

		[XmlElement(ElementName = "uri", Namespace = "http://www.w3.org/2005/Atom")]
		public string Uri { get; set; } = string.Empty;
	}
}
