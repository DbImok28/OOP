using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Tests
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static class FileReader
        {
            public static void SerializeToXML<T>(string path, T data)
            {
                var xmlSer = new XmlSerializer(data.GetType());
                using (var f = new StreamWriter(path))
                {
                    xmlSer.Serialize(f, data);
                }
            }
            public static void SerializeToJson<T>(string path, T data)
            {
                string jsonData = JsonSerializer.Serialize(data);
                using (var f = new StreamWriter(path))
                {
                    f.WriteLine(jsonData);
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
            public static T DeserializeJson<T>(string path)
            {
                T data;
                using (var f = new StreamReader(path))
                {
                    data = JsonSerializer.Deserialize<T>(f.ReadToEnd());
                }
                return data;
            }
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var sections_ru = FileReader.DeserializeXML<ObservableCollection<ShopSection>>($"Products_ru.xml");
            var sections_en = FileReader.DeserializeXML<ObservableCollection<ShopSection>>($"Products_en.xml");

            var p = new ObservableCollection<Products2>();
            for (int i = 0; i < sections_ru.Count; i++)
            {
                p.Add(new Products2(sections_ru[i], sections_en[i]));
            }

            FileReader.SerializeToXML<ObservableCollection<Products2>>("Products.xml", p);
        }
    }
}
