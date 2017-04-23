using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelBattleView.Core
{
    public static class Serializer
    {
        public static T Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value);
        public static T Deserialize<T>(string value, string path)
        {
            using (var reader = new StreamReader(File.OpenRead(path)))
                return Deserialize<T>(reader.ReadToEnd());
        }

        public static string Serialize<T>(T value) => JsonConvert.SerializeObject(value, Formatting.Indented);
        public static string Serialize<T>(T value, string path)
        {
            using (var writer = new StreamWriter(File.OpenWrite(path)))
                writer.Write(Serialize(value));

            return path;
        }
    }
}
