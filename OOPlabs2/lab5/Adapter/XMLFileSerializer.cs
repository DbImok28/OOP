using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace lab5
{
    public class XMLFileSerializer
    {
        public static void SerializeToXML<T>(string path, T data)
        {
            var xmlSer = new XmlSerializer(data.GetType());
            using (var f = new StreamWriter(path))
            {
                xmlSer.Serialize(f, data);
            }
        }
        public static T DeserializeXML<T>(string path)
        {
            T data;
            var xmlSer = new XmlSerializer(typeof(T));
            using (var f = new StreamReader(path))
            {
                data = (T)xmlSer.Deserialize(f);
            }
            return data;
        }
    }
}
