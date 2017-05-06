using System.IO;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Utility {
    public static class JsonSerializerExtension {
        public static JsonSerializer Serializer { get; } = new JsonSerializer();

        public static void SerializeToFile(this JsonSerializer serializer, string filePath, object value) {
            using (var streamWriter = new StreamWriter(filePath))
            using (var jsonReader = new JsonTextWriter(streamWriter)) {
                serializer.Serialize(jsonReader, value);
            }
        }

        public static T DeserializeFromFile<T>(this JsonSerializer serializer, string filePath) {
            using (var streamReader = new StreamReader(filePath))
            using (var jsonReader = new JsonTextReader(streamReader)) {
                return serializer.Deserialize<T>(jsonReader);
            }
        }

        public static T Deserialize<T>(this JsonSerializer serializer, string value) => 
            serializer.Deserialize<T>(new JsonTextReader(new StringReader(value)));
    }
}
