using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core
{
    public class XmlSerialize
    {
        public static void ConvertListOfObjectsToXml<T>(ObservableCollection<T> list, string file, bool overwrite) 
        {
            bool append = !overwrite;

            using(StreamWriter writer = new StreamWriter(file, append, Encoding.UTF8)) 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                serializer.Serialize(writer, list);
            }
        }

        public static ObservableCollection<T> ConvertListOfObjectsFromXml<T>(ObservableCollection<T> list, string file, bool overwrite) 
        {
            bool append = !overwrite;

            ObservableCollection<T> info = new ObservableCollection<T>();

            var xmlSerializer = new XmlSerializer(typeof(ObservableCollection<T>));
            using(var reader = new StreamReader(file, append)) 
            {
                info = (ObservableCollection<T>)xmlSerializer.Deserialize(reader);
            }

            return info;
        }
    }
}
