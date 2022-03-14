using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace lab4
{
    public class DataController
    {
        public DataController()
        {
            apartments = new List<Apartment>();
            addresses = new List<Address>();
        }
        public void AddApartment(Apartment apartment)
        {
            apartments.Add(apartment);
        }
        public void AddAddress(Address address)
        {
            addresses.Add(address);
        }
        public void Save()
        {
            SerializeToXML("Apartment.xml", apartments);
            SerializeToXML("Address.xml", addresses);
        }
        public void Load()
        {
            apartments = DeserializeXML<List<Apartment>>("Apartment.xml");
            addresses = DeserializeXML<List<Address>>("Address.xml");
        }
        private static void SerializeToXML<T>(string path, T data)
        {
            var xmlSer = new XmlSerializer(data.GetType());
            using (var f = new StreamWriter(path))
            {
                xmlSer.Serialize(f, data);
            }
        }
        private static T DeserializeXML<T>(string path)
        {
            T data;
            var xmlSer = new XmlSerializer(typeof(T));
            using (var f = new StreamReader(path))
            {
                data = (T)xmlSer.Deserialize(f);
            }
            return data;
        }
        public List<Apartment> apartments { get; set; }
        public List<Address> addresses { get; set; }
    }
}
