using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;
using System.IO;

namespace Core
{
    public class JSONSerialize
    {
        public static void SerializeToJSON<T>(ObservableCollection<T> list, string jsonFile) 
        {          
            var options = new JsonSerializerOptions { WriteIndented = true };
            string? jsonString = JsonSerializer.Serialize(list, options);
            File.WriteAllText(jsonFile, jsonString);           
        }        

        public static ObservableCollection<T> DeserializeFromJson<T>(string jsonFile)
        {
            string jsonString = File.ReadAllText(jsonFile);
            ObservableCollection<T>? info = JsonSerializer.Deserialize<ObservableCollection<T>>(jsonString);
            return info;
        }
    }
}
