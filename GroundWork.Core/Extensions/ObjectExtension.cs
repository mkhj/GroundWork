	using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace GroundWork.Core.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNotNull(this object obj)
        {
            return (obj != null);
        }

        public static bool IsNull(this object obj)
        {
            return (obj == null);
        }

        public static string ToJSON(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                xmlSerializer.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) xmlSerializer.Deserialize(stream);
            }
        }
    }
}

