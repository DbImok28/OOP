using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Serialization;

namespace lab2
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
            var context = new ValidationContext(apartment);
            Validator.ValidateObject(apartment, context, true);
            apartments.Add(apartment);
            
        }
        public void AddAddress(Address address)
        {
            var context = new ValidationContext(address);
            Validator.ValidateObject(address, context, true);
            addresses.Add(address);
        }
        public void Save()
        {
            SerializeToXML("Apartment.xml", apartments);
            SerializeToXML("Address.xml", addresses);
        }
        public static void Save(List<Apartment> apartments, string path)
        {
            SerializeToXML(path, apartments);
        }
        public void Load()
        {
            apartments = DeserializeXML<List<Apartment>>("Apartment.xml");
            addresses = DeserializeXML<List<Address>>("Address.xml");
        }
        public static void Load(out List<Apartment> apartments, string path)
        {
            apartments = DeserializeXML<List<Apartment>>(path);
        }
        public void Load(string apartmentPath)
        {
            apartments = DeserializeXML<List<Apartment>>(apartmentPath);
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
