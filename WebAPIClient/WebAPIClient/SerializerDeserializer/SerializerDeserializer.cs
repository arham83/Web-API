using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using Newtonsoft.Json;

namespace WebAPIClient.SerializerDeserializer
{
    public class JsonHandler
    {
        public static T DeserializeJson<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
    public class MessagePackHandler
    {
        public static byte[] Serialize<T>(T obj)
        {
            return MessagePackSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes);
        }
    }
    public static class BinarySerialization
    {
        public static byte[] Serialize<T>(T obj)
        {
            var formatter = new BinaryFormatter();
            using (var memStream = new MemoryStream())
            {
                formatter.Serialize(memStream, obj);
                return memStream.ToArray();
            }
        }
        public static T Deserialize<T>(byte[] data)
        {
            var formatter = new BinaryFormatter();
            using (var deserializationStream = new MemoryStream(data))
            {
                return (T)formatter.Deserialize(deserializationStream);
            }
        }
    }
}
