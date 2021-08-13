using System.Xml.Serialization;

namespace DiscordBot.Data.Youtube.Models
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Feed));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Feed)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
	public class LinkInfoRemote
	{

		[XmlAttribute(AttributeName = "rel", Namespace = "")]
		public string Relative { get; set; } = string.Empty; // can be self for called url itself or alternate

		[XmlAttribute(AttributeName = "href", Namespace = "")]
		public string Link { get; set; } = string.Empty; // rel == alternate: link is channel or video, rel == self link to xml
	}
}
