using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIServer.Miscellaneous
{
    public class Misc
    {
        public static string GetPath(string relativePath)
        {
            string[] delimiters = { "bin" };
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] parts = currentDirectory.Split(delimiters, StringSplitOptions.None);

            string fullPath = Path.Combine(parts[0], relativePath);
            return fullPath;
        }
        public class JsonHandler
        {
            public static T DeserializeJson<T>(string filePath)
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
