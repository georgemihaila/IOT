using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Helpers
{
    /// <summary>
    /// Provides functionality for serializing and deserializing data.
    /// </summary>
    public static class SerializationHelper
    {
        public enum SerializationType { XML, Binary };
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="o">The object to be serialized.</param>
        /// <param name="filename">The file name for the object.</param>
        /// <param name="serializationType">The type of serialization.</param>
        public static void SerializeObject(this object o, string filename, SerializationType serializationType = SerializationType.XML)
        {
            if (o == null) return;
            switch (serializationType)
            {
                case SerializationType.Binary:
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                    {
                        binaryFormatter.Serialize(fileStream, o);
                    }
                    break;
                case SerializationType.XML:
                    XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
                    using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                    {
                        xmlSerializer.Serialize(fileStream, o);
                    }
                    break;
            }
        }

        /// <summary>
        /// Deserializes an object.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="filename">The object file location</param>
        /// <param name="deserializationType">The type of deserialization.</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string filename, SerializationType deserializationType = SerializationType.XML)
        {
            switch (deserializationType)
            {
                case SerializationType.Binary:
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                    {
                        return (T)binaryFormatter.Deserialize(fileStream);
                    }
                case SerializationType.XML:
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                    {
                        return (T)xmlSerializer.Deserialize(fileStream);
                    }
            }
            return default;
        }
    }
}
