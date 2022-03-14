using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class BrestAddressFactory : IAddressFactory
    {
        public Address CreateAddress(string District, string Street, string House, string Building, string ApartmentNumber)
        {
            return new Address("Беларусь", "Брест", District, Street, House, Building, ApartmentNumber);
        }
    }
}
