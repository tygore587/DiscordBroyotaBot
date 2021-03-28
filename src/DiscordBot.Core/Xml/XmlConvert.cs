using System;
using System.IO;
using System.Xml.Serialization;

namespace DiscordBot.Core.Xml
{
    public static class XmlConvert
    {
        public static string SerializeObject<T>(T dataObject)
        {
            if (Equals(dataObject, default(T)))
                return string.Empty;

            try
            {
                using var stringWriter = new StringWriter();

                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(stringWriter, dataObject);

                return stringWriter.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static T? DeserializeObject<T>(string xml)
            where T : new()
        {
            if (string.IsNullOrEmpty(xml))
                return default;

            try
            {
                using var stringReader = new StringReader(xml);

                var serializer = new XmlSerializer(typeof(T));

                var deserializedObject = serializer.Deserialize(stringReader);

                return deserializedObject is T tResult ? tResult : default;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}