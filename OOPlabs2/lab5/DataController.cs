using System;
using System.Collections.Generic;

namespace lab5
{
    public class DataController : IDataController
    {
        public DataController()
        {
            apartments = new List<Apartment>();
            addresses = new List<Address>();
            file = new FileAdapter(this);
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
            file.Save();
        }
        public void Load()
        {
            file.Load();
        }
        public List<Apartment> apartments { get; set; }
        public List<Address> addresses { get; set; }
        private FileAdapter file;
    }
}
