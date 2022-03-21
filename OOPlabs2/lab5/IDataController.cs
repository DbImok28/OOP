using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public interface IDataController
    {
        void AddApartment(Apartment apartment);
        void AddAddress(Address address);
        void Save();
        void Load();
        List<Apartment> apartments { get; set; }
        List<Address> addresses { get; set; }
    }
}
