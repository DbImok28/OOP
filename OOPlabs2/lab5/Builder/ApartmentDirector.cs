using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class ApartmentDirector
    {
        public ApartmentDirector(IApartmentBuilder builder)
        {
            Builder = builder;
        }
        public Apartment GetApartment(int footage, int numberOfRooms, int yearOfConstruction, string material, int floor, Address address)
        {
            Builder.BuildRooms(footage, numberOfRooms, yearOfConstruction, material, floor, address);
            return Builder.GetApartment();
        }
        IApartmentBuilder Builder;
    }
}
